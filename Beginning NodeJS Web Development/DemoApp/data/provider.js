var mongo = require('mongodb'),
    mongoClient = mongo.MongoClient,
    BSON = mongo.BSONPure,
    localDb = 'mongodb://localhost/princess';

exports.list = function(collectionName, callback){
    mongoClient.connect(process.env.MONGOLAB_URI || localDb, null, function(err, db){
        if(err){
            return callback(err);
        }

        db.collection(collectionName, function(err, collection){
            collection.find().toArray(function(err, items){
                if(!err){
                    callback(null, items);
                }else{
                    callback(err);
                }
                db.close();
            });
        });
    });
};

exports.findById = function(collectionName, id, callback){

    mongoClient.connect(process.env.MONGOLAB_URI || localDb, null, function(err, db){
        if(err){
            return callback(err);
        }
        db.collection(collectionName, function(err, collection){
            var oId = new BSON.ObjectID(id);
            collection.findOne({_id:oId}, function(err, item){
                if(!err){
                    callback(null, item);
                }else{
                    callback(err);
                }
                db.close();
            });
        });
    });
};

exports.find = function(collectionName, query, callback){
    mongoClient.connect(process.env.MONGOLAB_URI || localDb, null, function(err, db){
        if(err){
            return callback(err);
        }
        db.collection(collectionName, function(err, collection){
            collection.find(query).toArray(function(err, items){
                if(!err){
                    db.close();
                    callback(null, items);
                }else{
                    callback(err);
                }
            });
        });
    });
};

exports.add = function(collectionName, object, callback){
    mongoClient.connect(process.env.MONGOLAB_URI || localDb, null, function(err, db){
        if(err){
            callback(err);
        }
        db.collection(collectionName, function(err, collection){
            collection.insert(object, function(err){

                if(err){
                    return callback(err);
                }

                collection.findOne(object, function(err, item){
                    if(!err){
                        db.close();
                        callback(null, item);
                    }else{
                        callback(err);
                    }
                });

            });
        });
    });
};

exports.update = function(collectionName, query, action, callback){
    mongoClient.connect(process.env.MONGOLAB_URI || localDb, null, function(err, db){
        if(err){
            return callback(err);
        }
        db.collection(collectionName, function(err, collection){
            collection.update(query, action, function(err){

                if(err){
                    return callback(err);
                }

                collection.findOne(query, function(err, item){
                    if(!err){
                        db.close();
                        callback(null, item);
                    }else{
                        callback(err);
                    }
                });
            });
        });
    });
};

exports.save = function(collectionName, object, callback){
    mongoClient.connect(process.env.MONGOLAB_URI || localDb, null, function(err, db){
        if(err){
            callback(err);
        }
        db.collection(collectionName, function(err, collection){
            collection.save(object, function(err){

                if(err){
                    //console.log(err);
                    return callback(err);
                }

                collection.findOne(object, function(err, item){
                    if(!err){
                        db.close();
                        callback(null, item);
                    }else{
                        callback(err);
                    }
                });

            });
        });
    });
};

exports.delete = function(collectionName, query, callback){
    mongoClient.connect(process.env.MONGOLAB_URI || localDb, null, function(err, db){
        if(err){
            callback(err);
        }
        db.collection(collectionName, function(err, collection){
            collection.remove(query, function(err){

                if(err){
                    return callback(err);
                }

                return callback(null);

            });
        });
    });
};
