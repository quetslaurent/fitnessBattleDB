USE sql_fitness_battle;

INSERT INTO unit (type) VALUES ('km');
INSERT INTO unit (type) VALUES ('m');
INSERT INTO unit (type) VALUES ('repetitions');
INSERT INTO unit (type) VALUES ('swimming length');
INSERT INTO unit (type) VALUES ('min');
INSERT INTO unit (type) VALUES ('sec');


INSERT INTO category (categoryName) VALUES ('Cardio');
INSERT INTO category (categoryName) VALUES ('Upper Body');
INSERT INTO category (categoryName) VALUES ('Lower Body');
INSERT INTO category (categoryName) VALUES ('Other');


INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Burpees',15,3,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Jumping Rope',120,6,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Running',1,1,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Jumping Jack',40,3,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Mountain Climber',40,3,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Swimming',3,4,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Cycling',2.5,1,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Training Video',7,5,1);

INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Curl',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Dips',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Pull over',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Dumbbell triceps',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Frontal elevation',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Frontal elevation',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Abdominals',30,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Bicycle crunches',30,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Crunch',40,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Abdominals cladding',120,6,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Leg raises',30,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Side plank',120,6,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Reverse cruches',40,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Russian Twist',40,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Pull Up',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Superman',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Hyper extension',25,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Push up',30,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Incline press',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Bench press',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Peck deck',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Pull Up',20,3,2);


INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Squat jump',25,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Squat',35,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Single leg bridge',30,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Leg press',20,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Hip thrust',35,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Lunge',30,3,3);

INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) VALUES ('Other activity',30,5,4);


INSERT INTO userFitness (name,password,email,role) VALUES ('admin','8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918','admin@gmail.com','admin');
INSERT INTO userFitness (name,password,email,role) VALUES ('user','04F8996DA763B7A969B1028EE3007569EAF3A635486DDAB211D512C85B9DF8FB','user@gmail.com','user');