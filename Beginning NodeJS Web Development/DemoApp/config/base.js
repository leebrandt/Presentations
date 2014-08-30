var express = require('express'),
    path = require('path'),
    bodyParser = require('body-parser'),
    logger = require('morgan');

var app = express();
app.use(logger('dev'));
app.use(bodyParser.urlencoded());
app.set('views', path.join(__dirname, '../views'));
app.set('view engine', 'jade');
app.use(require('stylus').middleware(path.join(__dirname, '../public')));
app.use(express.static(path.join(__dirname, '../public')));

var base = require('../routes/default');
var chars = require('../routes/characters');
var cast = require('../controllers/cast');

app.use('/', base);
app.use('/char', chars);
app.use('/cast', cast);
// nobody else has made a match to the requested URL.
// Must not be here. Let the user know.
app.use(function(req,res,next){
    var err = new Error('You keep using that URL. I do not think it goes where you think it goes.');
    err.status = 404;
    next(err);
});

// Handle all error cases
app.use(function(err,req,res){
    res.send({
        error: err.status || 500,
        message: err.message || 'You are in the pit of despair. Don\'t even THINK about trying to escape.'
    });
});

module.exports = app;
