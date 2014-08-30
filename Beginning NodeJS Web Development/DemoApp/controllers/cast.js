var dataProvider = require('../data/provider');
express = require('express'),
    router = express.Router();

router.get('/', function(req,res, next){
    dataProvider.list('cast', function(err, items){
        if(err){
            return next(err);
        }
        res.render('cast', {title:'Cast', cast:items});
    });
});
router.post('/', function(req,res,next){
    var newCharacter = {character:req.body['character'], actor:req.body['actor']};
    dataProvider.add('cast', newCharacter, function(err){
        if(err){
            return next(err);
        }
        res.redirect('/cast');
    });
});

module.exports = router;
