SELECT B.permission_id,C.display_name,C.`type`,A.name,A.description,A.parent_name,A.is_menu FROM sys_permission A 
INNER JOIN sys_role_permission B 
ON A.id=B.permission_id
INNER JOIN sys_role C
ON B.role_id=C.id
-- WHERE A.parent_name='System'

-- 用户角色分配
SELECT B.user_id,A.user_name,A.`account`,A.`enable`,A.int_id,B.role_id
FROM sys_user A 
INNER JOIN  
sys_user_role B 
ON A.id=B.user_id


-- 角色和权限分配
SELECT D.`name` AS `role.Name`,A.role_id AS `role.id`,
A.system_type,B.`name` AS `permission.name`,
B.description AS `permission.menu&function`,
B.is_menu,B.`order`,B.system_type 
FROM sys_role D
INNER JOIN  sys_role_permission A
ON D.id=A.role_id
INNER JOIN sys_permission B 
ON A.permission_id=B.id
ORDER BY D.`name`

SELECT * FROM sys_permission
-- 1.管理 2.养护 3.管理及养护 4.第三方单位 5.超管 6.第三方开放
SELECT Id,`name`,`type`,en_code,zh_code,weburl,platform_type,is_used,
case 
    when platform_type ='1' then "管理"
    when platform_type ='2' then "养护"
    when platform_type ='3' then "管理及养护"
    when platform_type ='4' then "第三方单位"
    when platform_type ='5' then "超管"
    end as platform_name
FROM sys_platform WHERE weburl LIKE 'http://47.107.72.111%'

SELECT * FROM sys_role --系统角色表

SELECT * FROM sys_user --系统用户表
SELECT * FROM sys_user_role --用户所属角色
SELECT * FROM sys_role_permission ORDER BY role_id --角色所属权限

SELECT * FROM sys_user_platform

SELECT Id,UserId,UserTrueName,CompanyId,IsDeleted FROM gdbs_dev.sys_user_details --用户详情

-- 账号名和ChineseFullName
SELECT A.user_name,A.user_pwd,A.`account`,B.UserTrueName FROM gdbs_identity.sys_user A  INNER  JOIN gdbs_dev.sys_user_details B 
ON A.id=B.UserId

