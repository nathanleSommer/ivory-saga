var systemDbNames = ["admin", "config", "local"]

function listDatabases(regExp) {
    return db.adminCommand("listDatabases").databases
        .map(function (database) { return database.name; })
        // Where db is not a mongodb system Db.
        .filter(function (name) { return systemDbNames.indexOf(name) === -1; })
        // Where db matches regexp.
        .filter(function (name) { return name.match(regExp); });
};

var dbs = listDatabases(".");

dbs.forEach(function (dbName) {
    db.getSiblingDB(dbName).dropDatabase();
});
