/* use a separate schema */
/*create views for tables that might need to be independent eventually - note that these are read-only as views, and this is by design
so that the analytics database is not supposed to manipulate any data in these tables*/

Create schema analytics;

create or replace view analytics.students as 
select * from students;

create or replace view analytics.activities as 
select board_id as activity_id, name, difficulty, logo, title, description, prerequisite, goal from boards;

create or replace view analytics.logs as 
select * from logs;

/* these tables are specific to analytics database, so it is fine to use them without having views*/

create table analytics.subjects
(
  subject_id SERIAL,
  subject_name TEXT
);


create table analytics.topics
(
  topic_id SERIAL,
  subject_id INT,
  topic_name TEXT
);

create table analytics.subtopics
(
  subtopic_id SERIAL,
  topic_id INT,
  subtopic_name TEXT
);

create table analytics.activitiestosubtopics
(
  subtopic_id INT,
  activity_id INT
);