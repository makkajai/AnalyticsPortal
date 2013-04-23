/*this is a temporary script to create test setup data for analytics till the real thing is ready */

insert into analytics.subjects
values (1, 'Maths'), (2, 'Science'), (3, 'Reading');

delete from analytics.subjects


insert into analytics.topics
values (1, 1, 'Algebra'), (2, 1, 'Geometry'), (3, 1, 'Money'), (4, 3, 'Alphabets'), (4, 3, 'Reading');

select * from analytics.topics


insert into analytics.subtopics
values (1, 1, 'Addition'), (2, 1, 'Subtraction'), (3, 1, 'Multiplication'), (4, 2, 'Shapes'), (5, 2, 'Graphs'), (6, 3, 'Simple'), 
(7, 3, 'fractional')


insert into analytics.activitiestosubtopics
values (3, 4), (1, 8), (2, 7), (5, 134), (5, 135), (6, 114), (6, 115), (7, 116), (7, 117)

select * from analytics.activitiestosubtopics