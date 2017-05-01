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
  , email_id varchar(255) not null
  , religion varchar(255) not null
  , deleted tinyint(4) DEFAULT 0
  , created_by varchar(255) not null
  , created_date timestamp default current_timestamp
  , modified_by varchar(255) null
  , modified_date timestamp null
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
  , expiry_date timestamp default current_timestamp()
  , user_agent varchar(1000) null
  , deleted tinyint(4) not null default 0
  , created_date timestamp default current_timestamp()
  , modified_date timestamp null
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

