var express = require('express');
router = express.Router();

router.get('/', function(req,res){
    res.render('index', {title:'Base', message:'As you wish'});
});

module.exports = router;
