SELECT * FROM bge_info ORDER BY id DESC --桥梁信息


SELECT * FROM bge_pipeline_info ORDER BY id DESC  --  附属管线

SELECT * FROM bge_substructure_info ORDER BY id DESC -- 下部结构



SELECT * FROM bge_ancillary_info ORDER BY id DESC  -- 附属工程

SELECT * FROM bge_superstructure_info ORDER BY id DESC -- 上部结构

SELECT * FROM bge_line_info ORDER BY id DESC --桥梁主线路

-- 一桥一档 字典表 tabler_id=89
SELECT A.id, A.tabler_id AS '桥梁线路ID'
-- ,D.bge_id AS '桥梁ID'
,A.dic_id,B.name,B.en_name AS '字段名',
C.data_name,A.Item_id AS '字段值',
B.name,B.belong_table_name
FROM bge_dictionary_sub_table A 
INNER JOIN bge_dictionar B ON A.dic_id=B.id 
INNER JOIN bge_dictionary_sub C ON A.Item_id=C.id   
-- INNER JOIN bge_line_info D ON A.tabler_id=D.id
-- WHERE A.dic_id IN('17','18','20','35') 
-- WHERE A.tabler_id ='88' AND B.belong_table_name='bge_info'
ORDER BY A.id DESC;

SELECT * FROM bge_dictionary_sub_table WHERE field_name='bge_line_info' ORDER BY id DESC;

-- 下部结构
SELECT * FROM bge_dictionary_sub_table WHERE tabler_id='92' AND field_name='bge_info' ORDER BY id DESC ;


SELECT * FROM bge_dictionary_sub_table A INNER JOIN bge_dictionary_sub B ON A.dic_id=B.id WHERE A.tabler_id=82


SELECT * FROM bge_dictionar A INNER JOIN bge_dictionary_sub B ON A.id=B.dic --字典表

SELECT * FROM bge_dictionar O INNER JOIN  bge_dictionary_sub
A ON O.id=A.dic
  left JOIN bge_dictionary_sub_table B ON A.id= B.Item_id 
 WHERE tabler_id=82


SELECT * FROM bge_dictionar WHERE belong_table_name='bge_superstructure_info'

SELECT * FROM bge_info ORDER BY id DESC

-- 桥梁人工检测，附件上传
SELECT * FROM files_info WHERE TABLE_NAME='bge_manual_monitor'


