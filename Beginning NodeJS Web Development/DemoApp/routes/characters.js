var express = require('express'),
    router = express.Router();

router.get('/westley', function(req,res){
    res.render('westley', {title:'The Fire Swamps', message: 'We\'ll never survive.'});
});

module.exports = router;
