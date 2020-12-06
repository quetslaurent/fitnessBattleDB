USE sql_fitness_battle;

DROP TABLE IF EXISTS userFitness;
DROP TABLE IF EXISTS trainingDate;
DROP TABLE IF EXISTS unit;
DROP TABLE IF EXISTS category;
DROP TABLE IF EXISTS activity;
DROP TABLE IF EXISTS training;

CREATE TABLE userFitness
(
    userId     INT IDENTITY NOT NULL,
    name   VARCHAR(100) NOT NULL,
    password   VARCHAR(100) NOT NULL,
    email   VARCHAR(100) NOT NULL,
    role   VARCHAR(50) NOT NULL,
    PRIMARY KEY (userId)
);

CREATE TABLE trainingDate
(
    trainingDateId    INT IDENTITY    NOT NULL,
    date DATETIME UNIQUE NOT NULL,
    PRIMARY KEY (trainingDateId)
);

CREATE TABLE unit
(
    unitId    INT IDENTITY NOT NULL,
    type  VARCHAR(100) NOT NULL,
    PRIMARY KEY (unitId)
);

CREATE TABLE category
(
    categoryId    INT IDENTITY NOT NULL,
    categoryName  VARCHAR(100) NOT NULL,
    PRIMARY KEY (categoryId)
);

CREATE TABLE activity
(
    activityId     INT IDENTITY NOT NULL,
    name   VARCHAR(100) NOT NULL,
    repetitionsNeeded NUMERIC(7,2) NOT NULL,
    aUnitId     INT NOT NULL,
    aCategoryId     INT NOT NULL,
    PRIMARY KEY (activityId),
    FOREIGN KEY (aUnitId) REFERENCES unit (unitId) ON DELETE CASCADE,
    FOREIGN KEY (aCategoryId) REFERENCES category (categoryId) ON DELETE CASCADE
);

CREATE TABLE training
(
    trainingId     INT IDENTITY NOT NULL,
    repetitions NUMERIC(7,2) NOT NULL,
    tActivityId INT NOT NULL,
    tUserId INT NOT NULL,
    tTrainingDateId INT NOT NULL,
    
    PRIMARY KEY (trainingId),
    FOREIGN KEY (tActivityId) REFERENCES activity (activityId) ON DELETE CASCADE,
    FOREIGN KEY (tUserId) REFERENCES userFitness (userId) ON DELETE CASCADE,
    FOREIGN KEY (tTrainingDateId) REFERENCES trainingDate (trainingDateId) ON DELETE CASCADE,
);