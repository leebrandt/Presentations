var app = require('./config/base');

app.set('port', process.env.PORT || 3000);

var server = app.listen(app.get('port'), function() {
    console.log('The magic is happening at: %s:%s',
        server.address().address ,
        server.address().port);
});
