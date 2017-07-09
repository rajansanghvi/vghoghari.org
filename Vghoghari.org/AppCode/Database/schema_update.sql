create table if not exists app_users
(
  id int(11) auto_increment primary key
  , fullname varchar(255) not null
  , username varchar(255) not null
  , hashed_password varchar(255) not null
  , device_id varchar(25) not null
  , auth_key varchar(40) not null
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

create table app_user_types
(
  id int(11) AUTO_INCREMENT primary key
  , user_id int(11) not null
  , user_type tinyint(4) default 1
  , deleted tinyint(4) DEFAULT 0
  , created_by varchar(255) not null
  , created_date datetime default now()
  , modified_by varchar(255) null
  , modified_date datetime null
)engine innoDb;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_user_types' and index_NAME = 'idx_app_user_types_user_id') then
    create index idx_app_user_types_user_id on app_user_types(user_id);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_user_types' and index_NAME = 'idx_app_user_types_user_id_user_type') then
    create index idx_app_user_types_user_id_user_type on app_user_types(user_id, user_type);
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

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_countries' and index_NAME = 'idx_app_countries_name') then
    create index idx_app_countries_name on app_countries(name);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_countries' and index_NAME = 'idx_app_countries_value') then
    create index idx_app_countries_value on app_countries(value);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_states' and index_NAME = 'idx_app_states_name') then
    create index idx_app_states_name on app_states(name);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_states' and index_NAME = 'idx_app_states_value') then
    create index idx_app_states_value on app_states(value);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_cities' and index_NAME = 'idx_app_cities_name') then
    create index idx_app_cities_name on app_cities(name);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_cities' and index_NAME = 'idx_app_cities_value') then
    create index idx_app_cities_value on app_cities(value);
  end if;
END;
CALL addIndex();

drop procedure if exists addCol;
CREATE PROCEDURE addCol() 
BEGIN
  if not exists(select 1 from information_schema.columns where TABLE_NAME = 'app_cities' and COLUMN_NAME = 'country_id') then
    ALTER TABLE app_cities
    Add country_id int(11) not null default 0
    after state_id;
  end if;
END;
call addCol();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_cities' and index_NAME = 'idx_app_cities_country_id') then
    create index idx_app_cities_country_id on app_cities(country_id);
  end if;
END;
CALL addIndex();

create table if not exists  app_biodata_basic_infos
(
  id int(11) auto_increment primary key
  , user_id int(11) not null
  , code varchar(100) not null
  , gender varchar(10) not null
  , fullname varchar(255) not null
  , dob datetime not null
  , marital_status varchar(100) not null
  , native varchar(500) not null
  , birth_place varchar(500) null
  , caste varchar(255) not null
  , profile_image varchar(255) null
  , approval_status tinyint(4) not null default 1
  , last_admin_action_by varchar(255) null
  , last_admin_action_date datetime null
  , deleted tinyint(4) not null default 0
  , created_by varchar(255) not null
  , created_date datetime default now()
  , modified_by varchar(255) null
  , modified_date datetime null
) engine InnoDb;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_basic_infos' and index_NAME = 'idx_app_biodata_basic_infos_code') then
    create index idx_app_biodata_basic_infos_code on app_biodata_basic_infos(code);
  end if;
END;
CALL addIndex();

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_basic_infos' and index_NAME = 'idx_app_biodata_basic_infos_user_id') then
    create index idx_app_biodata_basic_infos_user_id on app_biodata_basic_infos(user_id);
  end if;
END;
CALL addIndex();

create table if not exists app_biodata_personal_infos
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , height_ft tinyint(4) not null
  , height_in tinyint(4) not null
  , weight float null
  , blood_group varchar(10) null
  , manglik varchar(10) null
  , horoscope_match varchar(10) null
  , food_habits varchar(10) null
) engine InnoDb;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_personal_infos' and index_NAME = 'idx_app_biodata_personal_infos_biodata_id') then
    create index idx_app_biodata_personal_infos_biodata_id on app_biodata_personal_infos(biodata_id);
  end if;
END;
CALL addIndex();

create table if not exists app_biodata_education_infos
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , education varchar(100) not null
  , degrees_achieved varchar(1000) null
  , details varchar(1000) null
)engine innoDb;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_education_infos' and index_NAME = 'idx_app_biodata_education_infos_biodata_id') then
    create index idx_app_biodata_education_infos_biodata_id on app_biodata_education_infos(biodata_id);
  end if;
END;
CALL addIndex();

create table if not exists app_biodata_occupation_infos
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , occupation varchar(100) not null
  , profession_sector varchar(1000) null
  , annual_income decimal(10, 2) null
  , details varchar(1000) null
) engine InnoDb;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_occupation_infos' and index_NAME = 'idx_app_biodata_occupation_infos_biodata_id') then
    create index idx_app_biodata_occupation_infos_biodata_id on app_biodata_occupation_infos(biodata_id);
  end if;
END;
CALL addIndex();

create table if not exists app_biodata_family_infos
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , father_name varchar(255) not null
  , mother_name varchar(255) not null
  , no_of_married_bro tinyint(4) not null default 0
  , no_of_married_sis tinyint(4) not null default 0
  , no_of_unmarried_bro tinyint(4) not null default 0
  , no_of_unmarried_sis tinyint(4) not null default 0
  , details varchar(1000) null
) engine InnoDb;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_family_infos' and index_NAME = 'idx_app_biodata_family_infos_biodata_id') then
    create index idx_app_biodata_family_infos_biodata_id on app_biodata_family_infos(biodata_id);
  end if;
END;
CALL addIndex();

create table if not exists app_biodata_mosal_infos
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , mosal_name varchar(255) not null
) engine InnoDb;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_mosal_infos' and index_NAME = 'idx_app_biodata_mosal_infos_biodata_id') then
    create index idx_app_biodata_mosal_infos_biodata_id on app_biodata_mosal_infos(biodata_id);
  end if;
END;
CALL addIndex();

create table if not exists app_biodata_contact_infos
(
  id int(11) auto_increment primary key
  , biodata_id int(11) not null
  , address varchar(1000) not null
  , city varchar(500) null
  , mobile_number varchar(20) not null,
  email_id varchar(255) null
) engine InnoDb;

drop procedure if exists addIndex;
CREATE PROCEDURE addIndex() 
BEGIN
  if not exists(select 1 from information_schema.statistics where TABLE_NAME = 'app_biodata_contact_infos' and index_NAME = 'idx_app_biodata_contact_infos_biodata_id') then
    create index idx_app_biodata_contact_infos_biodata_id on app_biodata_contact_infos(biodata_id);
  end if;
END;
CALL addIndex();

