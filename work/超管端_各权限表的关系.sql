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
SELECT A.role_id,A.system_type,B.`name`,
B.description,B.is_menu,B.`order`,B.system_type 
FROM sys_role_permission A
INNER JOIN sys_permission B 
ON A.permission_id=B.id
ORDER BY A.role_id