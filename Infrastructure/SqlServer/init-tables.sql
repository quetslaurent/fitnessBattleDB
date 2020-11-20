USE sql_fitness_battle;

DROP TABLE IF EXISTS userFitness;
DROP TABLE IF EXISTS trainingDate;
DROP TABLE IF EXISTS unit;
DROP TABLE IF EXISTS category;
DROP TABLE IF EXISTS activity;
DROP TABLE IF EXISTS training;

CREATE TABLE userFitness
(
    id     INT IDENTITY NOT NULL,
    name   VARCHAR(100) NOT NULL,
    password   VARCHAR(100) NOT NULL,
    email   VARCHAR(100) NOT NULL,
    admin   BIT NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE trainingDate
(
    id    INT IDENTITY    NOT NULL,
    date DATETIME UNIQUE NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE unit
(
    id    INT IDENTITY NOT NULL,
    type  VARCHAR(100) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE category
(
    id    INT IDENTITY NOT NULL,
    name  VARCHAR(100) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE activity
(
    id     INT IDENTITY NOT NULL,
    name   VARCHAR(100) NOT NULL,
    repetitions NUMERIC(7,2) NOT NULL,
    unitId     INT NOT NULL,
    categoryId     INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (unitId) REFERENCES unit (id),
    FOREIGN KEY (categoryId) REFERENCES category (id)
);

CREATE TABLE training
(
    id     INT IDENTITY NOT NULL,
    repetitions NUMERIC(7,2) NOT NULL,
    activityId INT NOT NULL,
    userId INT NOT NULL,
    trainingDateId INT NOT NULL,
    
    PRIMARY KEY (id),
    FOREIGN KEY (activityId) REFERENCES activity (id),
    FOREIGN KEY (userId) REFERENCES userFitness (id),
    FOREIGN KEY (trainingDateId) REFERENCES trainingDate (id),
);