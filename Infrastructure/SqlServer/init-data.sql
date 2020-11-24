﻿USE sql_fitness_battle;

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


INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Burpees',15,3,1);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Jumping Rope',120,6,1);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Running',1,1,1);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Jumping Jack',40,3,1);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Mountain Climber',40,3,1);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Swimming',3,4,1);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Cycling',2.5,1,1);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Training Video',7,5,1);

INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Curl',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Dips',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Pull over',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Dumbbell triceps',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Frontal elevation',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Frontal elevation',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Abdominals',30,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Bicycle crunches',30,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Crunch',40,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Abdominals cladding',120,6,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Leg raises',30,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Side plank',120,6,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Reverse cruches',40,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Russian Twist',40,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Pull Up',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Superman',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Hyperextension',25,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Push up',30,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Incline press',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Bench press',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Peck deck',20,3,2);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Pull Up',20,3,2);


INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Squat jump',25,3,3);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Squat',35,3,3);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Single leg bridge',30,3,3);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Leg press',20,3,3);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Hip thrust',35,3,3);
INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Lunge',30,3,3);

INSERT INTO activity (name,repetitions,aUnitId,aCategoryId) values ('Other activity',30,5,4);


INSERT INTO userFitness (name,password,email,admin) values ('admin','21232F297A57A5A743894A0E4A801FC3','admin@gmail.com',true);
INSERT INTO userFitness (name,password,email,admin) values ('user','EE11CBB19052E40B07AAC0CA060C23EE','user@gmail.com',false);