using System.Linq;
using System.Web.Mvc;
using FakeItEasy;
using FizzWare.NBuilder;
using Machine.Specifications;
using MvcContrib.TestHelper;
using SFT.Core.Data;
using SFT.Core.Data.NHibernate;
using SFT.Core.Domain.Authentication;
using SFT.Core.Services.Authentication;
using SFT.Web.UI.Controllers;
using SFT.Web.UI.Models;

namespace SFT.Specifications.Account
{
    [Subject("30 - Login")]
    public class When_a_user_wishes_to_login_to_the_site : With_the_main_site_routes_registered
    {
        It should_navigate_to_the_login_page = () =>
            "~/account/login".ShouldMapTo<AccountController>(ctrl=>ctrl.Login());
    }

    [Subject("30 - Login")]
    public class When_navigating_to_the_login_page
    {
        Establish context = () =>
            {
                _authService = A.Fake<AuthenticationService>();
                _accountController = new AccountController(_authService);
            };

        Because of = () => _result = _accountController.Login();

        It should_load_the_login_form = () =>
            _result.AssertViewRendered().ForView("Login");

        It should_load_an_empty_login_form = () =>
            _result.AssertViewRendered().ViewData.Model.ShouldBe(typeof(LoginModel));

        static AccountController _accountController;
        static ActionResult _result;
        static AuthenticationService _authService;
    }

    [Subject("30 - Login")]
    public class When_logging_in_with_valid_credentials
    {
        Establish context = () =>
            {
                _validLogin = new LoginModel { Username = "validUser", Password = "goodPa$$" };
                _authService = A.Fake<AuthenticationService>();
                A.CallTo(() => _authService.Authenticate(_validLogin.Username, _validLogin.Password)).Returns(true);
                _accountController = new AccountController(_authService);
            };

        Because of = () => _result = _accountController.Login(_validLogin);

        It should_authenticate_the_user = () =>
            A.CallTo(() => _authService.Authenticate(_validLogin.Username, _validLogin.Password)).MustHaveHappened();

        It should_sign_the_user_into_the_site = () =>
            A.CallTo(() => _authService.SignIn(_validLogin.Username)).MustHaveHappened();

        It should_return_the_user_to_the_home_page = () =>
            _result.AssertActionRedirect().ToAction<HomeController>(ctrl => ctrl.Index());

        static AccountController _accountController;
        static ActionResult _result;
        static LoginModel _validLogin;
        static AuthenticationService _authService;
    }

    [Subject("30 - Login")]
    public class When_logging_in_with_an_invalid_login
    {
        Establish context = () =>
        {
            _invalidLogin = new LoginModel { Username = "badUser", Password = "badPa$$" };
            _authService = A.Fake<AuthenticationService>();
            A.CallTo(() => _authService.Authenticate(_invalidLogin.Username, _invalidLogin.Password)).Returns(false);
            _accountController = new AccountController(_authService);
        };

        Because of = () => _result = _accountController.Login(_invalidLogin);

        It should_authenticate_the_user = () =>
            A.CallTo(() => _authService.Authenticate(_invalidLogin.Username, _invalidLogin.Password)).MustHaveHappened();

        It should_not_sign_the_user_into_the_site = () =>
            A.CallTo(() => _authService.SignIn(_invalidLogin.Username)).MustNotHaveHappened();

        It should_return_the_user_to_the_login_page = () =>
            _result.AssertViewRendered().ForView("Login");

        It should_let_the_user_know_that_their_login_attempt_was_unsuccessful = () =>
            _accountController.ModelState["login"].Errors.ShouldNotBeEmpty();

        static AccountController _accountController;
        static ActionResult _result;
        static LoginModel _invalidLogin;
        static AuthenticationService _authService;
    }

    [Subject("30 - Login")]
    public class When_authenticating_valid_user_credentials
    {
        Establish context = () =>
            {
                _username = "validUser";
                _password = "validP@$$";
                _userRepository = A.Fake<UserRepository>();
                A.CallTo(() => _userRepository.GetByUsername(_username))
                    .Returns(new User {Username = _username, Password = _password});
                _authService = new WebAuthenticationService(_userRepository);
            };

        Because of = () => _result = _authService.Authenticate(_username, _password);

        It should_find_the_user_in_storage_with_the_specified_username = () =>
            A.CallTo(() => _userRepository.GetByUsername(_username)).MustHaveHappened();

        It should_successfully_authenticate_the_user = () => _result.ShouldBeTrue();

        static WebAuthenticationService _authService;
        static string _password;
        static string _username;
        static bool _result;
        static UserRepository _userRepository;
    }

    [Subject("30 - Login")]
    public class When_authenticating_user_with_incorrect_password
    {
        Establish context = () =>
        {
            _username = "validUser";
            _password = "badP@$$";
            _userRepository = A.Fake<UserRepository>();
            _authService = new WebAuthenticationService(_userRepository);
        };

        Because of = () => _result = _authService.Authenticate(_username, _password);

        It should_search_storage_for_the_specified_username = () =>
            A.CallTo(() => _userRepository.GetByUsername(_username)).MustHaveHappened();

        It should_not_successfully_authenticate_the_user = () => _result.ShouldBeFalse();

        static WebAuthenticationService _authService;
        static string _password;
        static string _username;
        static bool _result;
        static UserRepository _userRepository;
    }

    [Subject("30 - Login")]
    public class When_authenticating_user_with_an_incorrect_username
    {
        Establish context = () =>
        {
            _username = "badUser";
            _password = "doesntmatterwhatthepasswordis";
            _userRepository = A.Fake<UserRepository>();
            A.CallTo(() => _userRepository.GetByUsername(_username)).Returns(null as User);
            _authService = new WebAuthenticationService(_userRepository);
        };

        Because of = () => _result = _authService.Authenticate(_username, _password);

        It should_search_storage_for_the_specified_username = () =>
            A.CallTo(() => _userRepository.GetByUsername(_username)).MustHaveHappened();

        It should_not_successfully_authenticate_the_user = () => _result.ShouldBeFalse();

        static WebAuthenticationService _authService;
        static string _password;
        static string _username;
        static bool _result;
        static UserRepository _userRepository;
    }

    [Subject("30 - Login")]
    public class When_finding_a_user_in_storage_by_username
    {
        Establish context = () =>
        {
            _username = "username";
            _repository = A.Fake<Repository>();
            A.CallTo(() => _repository.All<User>())
                .Returns(Builder<User>.CreateListOfSize(10)
                    .WhereTheFirst(3).Has(usr => usr.Username = "nottheone")
                    .AndTheNext(1).Has(usr => usr.Username = _username)
                    .Build().AsQueryable());
            _userRepository = new NHibernateUserRepository(_repository);
        };

        Because of = () => _result = _userRepository.GetByUsername(_username);

        It should_search_user_storage = () =>
            A.CallTo(() => _repository.All<User>()).MustHaveHappened();

        It should_return_the_user_with_the_specified_username = () =>
            _result.Username.ShouldEqual(_username);

        static NHibernateUserRepository _userRepository;
        static string _username;
        static Repository _repository;
        static User _result;
    }
}