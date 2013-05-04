/* mapping between user ids and student ids */
create table usertostudents
(
  user_id TEXT,
  student_login TEXT
);

/*needed for authentication */
CREATE TABLE "UserAuth"
(
  "Id" serial NOT NULL,
  "UserName" text,
  "Email" text,
  "PrimaryEmail" text,
  "FirstName" text,
  "LastName" text,
  "DisplayName" text,
  "BirthDate" timestamp without time zone,
  "BirthDateRaw" text,
  "Country" text,
  "Culture" text,
  "FullName" text,
  "Gender" text,
  "Language" text,
  "MailAddress" text,
  "Nickname" text,
  "PostalCode" text,
  "TimeZone" text,
  "Salt" text,
  "PasswordHash" text,
  "DigestHA1Hash" text,
  "Roles" text,
  "Permissions" text,
  "CreatedDate" timestamp without time zone NOT NULL,
  "ModifiedDate" timestamp without time zone NOT NULL,
  "RefId" integer,
  "RefIdStr" text,
  "Meta" text,
  CONSTRAINT "UserAuth_pkey" PRIMARY KEY ("Id")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "UserAuth"
  OWNER TO postgres;



CREATE TABLE "UserOAuthProvider"
(
  "Id" serial NOT NULL,
  "UserAuthId" integer NOT NULL,
  "Provider" text,
  "UserId" text,
  "UserName" text,
  "FullName" text,
  "DisplayName" text,
  "FirstName" text,
  "LastName" text,
  "Email" text,
  "BirthDate" timestamp without time zone,
  "BirthDateRaw" text,
  "Country" text,
  "Culture" text,
  "Gender" text,
  "Language" text,
  "MailAddress" text,
  "Nickname" text,
  "PostalCode" text,
  "TimeZone" text,
  "RefreshToken" text,
  "RefreshTokenExpiry" timestamp without time zone,
  "RequestToken" text,
  "RequestTokenSecret" text,
  "Items" text,
  "AccessToken" text,
  "AccessTokenSecret" text,
  "CreatedDate" timestamp without time zone NOT NULL,
  "ModifiedDate" timestamp without time zone NOT NULL,
  "RefId" integer,
  "RefIdStr" text,
  "Meta" text,
  CONSTRAINT "UserOAuthProvider_pkey" PRIMARY KEY ("Id")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "UserOAuthProvider"
  OWNER TO postgres;


-- COMMENTED OUT FOR NOW - SIMPLIFYING THE SCHEMA
/* use a separate schema */
/*create views for tables that might need to be independent eventually - note that these are read-only as views, and this is by design
so that the analytics database is not supposed to manipulate any data in these tables*/

/*Create schema analytics;

create or replace view analytics.students as 
select * from students;

create or replace view analytics.activities as 
select board_id as activity_id, name, difficulty, logo, title, description, prerequisite, goal from boards;

create or replace view analytics.logs as 
select * from logs;
*/

/* these tables are specific to analytics database, so it is fine to use them without having views*/
/* for now not used
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
*/


