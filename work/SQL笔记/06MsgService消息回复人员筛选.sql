select A.task_work_name as '主题名称',a.task_info as '内容',a.msg_type as '消息类型',a.document_no as '文号',c.user_name as '消息回复人姓名',C.task_back_content as '消息回复内容' from task_msg_main A  left join task_msg_recivesend_info B ON A.id=B.task_msg_main_id 
				  left join task_msg_back_contents C ON C.task_msg_recivesend_info_id=B.id 
					where C.task_msg_recivesend_info_id=2;
				 