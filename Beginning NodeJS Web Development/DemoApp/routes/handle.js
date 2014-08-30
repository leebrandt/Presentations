var express = require('express');
router = express.Router();

router.get('/yourway', function(req,res,next){
    throw new Error('My way is not very sportsmanlike.');
});

module.exports = router;
