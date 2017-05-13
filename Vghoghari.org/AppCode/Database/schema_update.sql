create table if not exists app_users
(
  id int(11) auto_increment primary key
  , fullname varchar(255) not null
  , username varchar(255) not null
  , hashed_password varchar(255) not null
  , device_id varchar(25) not null
  , auth_key varchar(40) not null
  , user_type tinyint(4) not null default 1
  , mobile_number varchar(20) not null
  , email_id varchar(255) null
  , deleted tinyint(4) default 0
  , created_by varchar(255) not null
  , created_date datetime default now()
  , modified_by varchar(255) null
  , modified_date datetime null
)engine innoDb charset=Utf8;


drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_users' and index_NAME = 'idx_app_users_username') then
    create index idx_app_users_username on app_users(username);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_users' and index_NAME = 'idx_app_users_device_id') then
    create index idx_app_users_device_id on app_users(device_id);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_users' and index_NAME = 'idx_app_users_device_id_auth_key') then
    create index idx_app_users_device_id_auth_key on app_users(device_id, auth_key);
  end if;
END;
CALL addIndex();

create TABLE if not exists app_sessions
(
  id int(11) AUTO_INCREMENT primary key
  , user_id int(11) not null
  , session_id varchar(255) not null
  , expiry_date datetime default now()
  , user_agent varchar(1000) null
  , deleted tinyint(4) not null default 0
  , created_by varchar(255) not null
  , created_date datetime default now()
  , modified_by varchar(255) null
  , modified_date datetime null
)engine innoDb charset = utf8;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_sessions' and index_NAME = 'idx_app_sessions_session_id') then
    create index idx_app_sessions_session_id on app_sessions(session_id);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_sessions' and index_NAME = 'idx_app_sessions_user_id') then
    create index idx_app_sessions_user_id on app_sessions(user_id);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_sessions' and index_NAME = 'idx_app_sessions_user_id_session_id') then
    create index idx_app_sessions_user_id_session_id on app_sessions(user_id, session_id);
  end if;
END;
CALL addIndex();

create table if not exists  app_biodata_details
(
  id int(11) auto_increment primary key
  , user_id int(11) not null
  , code varchar(40) not null
  , candidate_name varchar(255) not null
  , dob datetime not null
  , birth_place varchar(255) not null
  , height_feet tinyint(4) not null default 0
  , height_inch tinyint(4) not null default 0
  , weight float not null default 0
  , blood_group tinyint(4) default 0
  , manglik tinyint(4) default 0
  , horoscope_match tinyint(4) default 0
  , email_id varchar(255) null
  , caste tinyint(4) not null default 0
  , other_caste varchar(255) null
  , native_place varchar(255) not null
  , residence_addr varchar(1000) not null
  , country varchar(500) null
  , state varchar(500) null
  , city varchar(500) null
  , mobile_number varchar(20) null
  , mosal varchar(255) null
  , diet tinyint(4) not null default 0
  , deleted tinyint(4) not null default 0
  , created_by varchar(255) not null
  , created_date datetime default now()
  , modified_name varchar(255) null
  , modified_date datetime null
) engine InnoDb;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_details' and index_NAME = 'idx_app_biodata_details_code') then
    create index idx_app_biodata_details_code on app_biodata_details(code);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_details' and index_NAME = 'idx_app_biodata_details_user_id') then
    create index idx_app_biodata_details_user_id on app_biodata_details(user_id);
  end if;
END;
CALL addIndex();

create table if not exists app_biodata_education_details
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , highest_education tinyint(4) not null default 0
  , degrees_secured varchar(1000) NULL
  , college varchar(255) null
  , details varchar(1000) null
)engine innoDb;

create table if not exists app_biodata_occupation_details
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , designation varchar(255) null
  , occupation tinyint(4) not null
  , details varchar(1000) null
  , annual_income int(10) default 0
) engine InnoDb;

create table if not exists app_biodata_family_details
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , father_name varchar(255) null
  , mother_name varchar(255) NULL
  , designation varchar(255) NULL
  , occupation tinyint(4) default 0
  , details varchar(1000) null
) engine InnoDb;

create table if not exists app_biodata_sibbling_details
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , name varchar(255) not null
  , married_to varchar(255) null
  , son_daughter_of varchar(255) null
  , native varchar(500) null
  , deleted tinyint(4) not null default 0
) engine InnoDb;