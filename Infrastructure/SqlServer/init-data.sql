USE sql_fitness_battle;

INSERT INTO unit (type) values ('km');
INSERT INTO unit (type) values ('m');
INSERT INTO unit (type) values ('repetitions');
INSERT INTO unit (type) values ('swimming length');
INSERT INTO unit (type) values ('min');
INSERT INTO unit (type) values ('sec');


INSERT INTO category (categoryName) values ('Cardio');
INSERT INTO category (categoryName) values ('Upper Body');
INSERT INTO category (categoryName) values ('Lower Body');
INSERT INTO category (categoryName) values ('Other');


INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Burpees',15,3,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Jumping Rope',120,6,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Running',1,1,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Jumping Jack',40,3,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Mountain Climber',40,3,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Swimming',3,4,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Cycling',2.5,1,1);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Training Video',7,5,1);

INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Curl',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Dips',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Pull over',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Dumbbell triceps',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Frontal elevation',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Frontal elevation',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Abdominals',30,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Bicycle crunches',30,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Crunch',40,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Abdominals cladding',120,6,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Leg raises',30,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Side plank',120,6,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Reverse cruches',40,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Russian Twist',40,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Pull Up',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Superman',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Hyper extension',25,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Push up',30,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Incline press',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Bench press',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Peck deck',20,3,2);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Pull Up',20,3,2);


INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Squat jump',25,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Squat',35,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Single leg bridge',30,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Leg press',20,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Hip thrust',35,3,3);
INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Lunge',30,3,3);

INSERT INTO activity (name,repetitionsNeeded,aUnitId,aCategoryId) values ('Other activity',30,5,4);


INSERT INTO userFitness (name,password,email,admin) values ('admin','8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918','admin@gmail.com',true);
INSERT INTO userFitness (name,password,email,admin) values ('user','04F8996DA763B7A969B1028EE3007569EAF3A635486DDAB211D512C85B9DF8FB','user@gmail.com',false);