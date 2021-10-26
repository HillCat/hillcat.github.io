using GDBS.BridgeService.Domain;
using GDBS.BridgeService.Domain.TaskEntitys;
using GDBS.Shared.Data;
using GDBS.Shared.Data.Entity.Jket;
using GDBS.Shared.Data.Entity.Model;

using Microsoft.EntityFrameworkCore;

using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace GDBS.BridgeService.EntityFrameworkCore
{


    /// <summary>
    /// ED DbContext 
    /// </summary>
    [ConnectionStringName("BridgeService")]
    public class BridgeServiceDbContext : AbpDbContext<BridgeServiceDbContext>
    {

        #region 维修加固Entity
        /// <summary>
        ///  维修加固主表
        /// </summary>
        public DbSet<RepairReinforceEntity> RepairReinforceEntitys { get; set; }
        /// <summary>
        /// 维修加固病害信息表
        /// </summary>
        public DbSet<RepairReinforceDiseaseEntity> RepairReinforceDiseaseEntitys { get; set; }
        /// <summary>
        /// 维修加固 工作事项表
        /// </summary>
        public DbSet<RepairWorkinfoEntity> RepairWorkinfoEntitys { get; set; }

        #endregion

        #region 应急处置
        ///// <summary>
        ///// 应急中选择的多个桥梁表
        ///// </summary>
        //public DbSet<EventBridgeEntity> EventBridgeEntitys { get; set; }

        /// <summary>
        /// 应急处置-主表
        /// </summary>
        public DbSet<EventEmergencyEntity> EventEmergencyEntitys { get; set; }
        /// <summary>
        /// 实时动态
        /// </summary>
        public DbSet<EventNewsEntity> EventNewsEntitys { get; set; }
        /// <summary>
        /// 事件解除
        /// </summary>
        public DbSet<EventRelieveEntity> EventRelieveEntitys { get; set; }

        #endregion

        //#region 通讯录       /*  工作沟通为收发文，单独的服务和数据库

        //#endregion

        #region 文件图片仓储表
        /// <summary>
        /// 文档文件上传记录信息表,,文件类型：1图片 2文档 3视频,4其他,关联表code
        /// </summary>
        public DbSet<FilesInfoEntity> FilesInfoEntity { get; set; }
        #endregion


        #region 检测服务Entity
        public DbSet<DetectionSpecial> DetectionSpecials { get; set; }
        public DbSet<DetectionNdt> DetectionNdts { get; set; }
        public DbSet<DetectionLoadTest> DetectionLoadTests { get; set; }
        public DbSet<DetectionStaticTest> DetectionStaticTests { get; set; }
        public DbSet<DetectionBcl> Detection_Bcls { get; set; }
        public DbSet<DetectioAppearence> DetectioAppearences { get; set; }
        /// <summary>
        /// 定期检测-报表
        /// </summary>
        public DbSet<DetectionBclReportEntity> DetectionBclReportEntity { get; set; }
        #endregion

        #region 桥梁监测--->人工监测(新增&&测点配置)
        /// <summary>
        /// 测点版本数据主表
        /// </summary>
        public DbSet<BgeManualMonitorEntity> BgeManualMonitorEntity { get; set; }
        /// <summary>
        /// 测点参数类型字典表
        /// </summary>
        public DbSet<BgeManualMonitorDictEntity> BgeManualMonitorDictEntity { get; set; }
        /// <summary>
        /// 测点数据详情表
        /// </summary>
        public DbSet<BgeManualMonitorPointDetailEntity> BgeManualMonitorPointDetailEntity { get; set; }
        #endregion

        #region 桥梁v0.5 时定义的实体
        /// <summary>
        /// 桥梁信息基础表
        /// </summary>
        public DbSet<BgeInfo> BgeInfos { get; set; }

        /// <summary>
        /// 字典分类表
        /// </summary>
        public DbSet<Bge_Dictionar_Class> Bge_Dictionar_ClassS { get; set; }

        /// <summary>
        /// 字典表
        /// </summary>
        public DbSet<Bge_Dictionar> Bge_Dictionars { get; set; }

        /// <summary>
        /// 选项表
        /// </summary>
        public DbSet<Bge_Dictionary_Sub> Bge_Dictionary_Subs { get; set; }


        /// <summary>
        /// 字典桥梁关系表
        /// </summary>
        public DbSet<Bge_Dictionary_Sub_Table> Bge_Dictionary_Sub_Tables { get; set; }



        /// <summary>
        ///日志
        /// </summary>
        public DbSet<Logo_Api> Logo_Apis { get; set; }


        /// <summary>
        /// 基础信息
        /// </summary>

        public DbSet<InstituTion> Bge_Institutions { get; set; }


        /// <summary>
        /// 桥梁档案
        /// </summary>
        public DbSet<BegArchive> BegArchives { get; set; }


        /// <summary>
        /// 桥梁图片
        /// </summary>
        public DbSet<Bgelogo> Bgelogos { get; set; }


        /// <summary>
        /// 桥梁线路
        /// </summary>
        public DbSet<Bge_Line_Info> Bge_Line_Infos { get; set; }

        /// <summary>
        /// 桥梁线路上部结构信息表
        /// </summary>
        public DbSet<BgeSuperstructureInfo> Bge_Superstructure_Infos { get; set; }

        /// <summary>
        /// 桥梁线路下部结构信息表
        /// </summary>
        public DbSet<BgesuBstructureInfo> bge_Substructure_Infos { get; set; }


        /// <summary>
        /// 桥梁附属工程结构信息表
        /// </summary>
        public DbSet<BgeAncillaryInfo> bge_Ancillary_Infos { get; set; }

        /// <summary>
        /// 桥梁线路附属管线信息表
        /// </summary>
        public DbSet<BgePipelineInfo> bgePipelineInfos { get; set; }

        public DbSet<SysCity> SysCities { get; set; }
        public DbSet<SysArea> SysAreas { get; set; }
        public DbSet<SysProvince> SysProvinces { get; set; }

        public DbSet<BgeLine> BgeLines { get; set; }

        /// <summary>
        /// 桥梁线路信息表
        /// </summary>
        public DbSet<Bge_Line_Info> BgeLineInfo { get; set; }
        /// <summary>
        /// 历史桥梁名称表
        /// </summary>
        public DbSet<BgeHistoryName> BgeHistoryNames { get; set; }
        public DbSet<BgeVersion> BgeVersions { get; set; }

        public DbSet<BgeMate> BgeMates { get; set; }

        public DbSet<BgeLineArc> BgeLineArc { get; set; }

        public DbSet<BgeStruMate> BgeStruMate { get; set; }
        public DbSet<BgeStruAttr> BgeStruAttr { get; set; }

        public DbSet<BgeStruArc> BgeStruArc { get; set; }

        public DbSet<BgeStruPbmType> BgeStruPbmType { get; set; }
        public DbSet<BgeMateArc> BgeMateArc { get; set; }

        public DbSet<BgeStruAttr> BgeStruAttrs { get; set; }
        public DbSet<BgePartAttr> BgePartAttrs { get; set; }
        public DbSet<BgeSpanAttr> BgeSpanAttrs { get; set; }

        public DbSet<BgeStru> BgeStrus { get; set; }
        public DbSet<BgeSpan> BgeSpan { get; set; }

        public DbSet<BgeSpanAttrValue> BgeSpanAttrValue { get; set; }
        public DbSet<SysProvince> SysProvince { get; set; }
        public DbSet<SysCity> SysCity { get; set; }

        public DbSet<SysArea> SysArea { get; set; }
        public DbSet<SysTown> SysTown { get; set; }

        public DbSet<BgePart> BgePart { get; set; }

        public DbSet<BgePartAttrValue> BgePartAttrValue { get; set; }
        public DbSet<BgeEle> BgeEle { get; set; }
        public DbSet<BgeEleAttrValue> BgeEleAttrValue { get; set; }

        public DbSet<Linecretelock> Linecreatelock { get; set; }

        public DbSet<DatPbm> DatPbm { get; set; }
        public DbSet<PrjBge> PrjBge { get; set; }
        public DbSet<BgeVersionTask> BgeVersionTasks { get; set; }

        public DbSet<BgeEleType> BgeEleTypes { get; set; }

        public DbSet<BgeEleAttr> BgeEleAttrs { get; set; }
        public DbSet<PrjBge> PrjBges { get; set; }
        public DbSet<PrjInfo> PrjInfos { get; set; }
        public DbSet<SysCom> SysComs { get; set; }
        public DbSet<SysUserDetails> SysUserDetails { get; set; }
        public DbSet<DatChart> DatCharts { get; set; }
        public DbSet<DatPbmTypeSpecInputValue> DatPbmTypeSpecInputValues { get; set; }
        public DbSet<DatPbmTypeSpecSelectValue> DatPbmTypeSpecSelectValues { get; set; }
        public DbSet<PbmTypeSpecInput> PbmTypeSpecInputs { get; set; }
        public DbSet<PbmTypeSpecSelect> PbmTypeSpecSelects { get; set; }
        public DbSet<BgeSpanAttrValue> BgeSpanAttrValues { get; set; }
        public DbSet<BgeEleAttrValue> BgeEleAttrValues { get; set; }
        public DbSet<PbmType> PbmTypes { get; set; }

        public DbSet<PrjSlnBge> PrjSlnBges { get; set; }

        public DbSet<DatLog> DatLogs { get; set; }
        public DbSet<DatLogOpContext> DatLogOpContexts { get; set; }
        public DbSet<PrjSln> PrjSlns { get; set; }
        public DbSet<PrjSlnUser> PrjSlnUsers { get; set; }

        public DbSet<Inspections> inspections { get; set; }
        /// <summary>
        ///巡查信息 
        /// </summary>
        public DbSet<InspectionsInfo> inspectionsInfos { get; set; }

        public DbSet<InspectionsInfoDisease> InspectionsInfoDiseases { get; set; }
        /// <summary>
        /// 巡查项
        /// </summary>
        public DbSet<InspectionsiTms> InspectionItems { get; set; }
        /// <summary>
        /// 病害类型
        /// </summary>
        public DbSet<InspectionDamageType> InspectionDamageTypes { get; set; }

        /// <summary>
        /// 桥梁运行天数，巡查等统计
        /// </summary>
        public DbSet<BrigeStatistics> BrigeStatistics { get; set; }

        /// <summary>
        /// word文档下载的日志记录，方便日后查看删除等操作
        /// </summary>
        public DbSet<Inspections_DownloadLogs> Inspections_DownloadLogs { get; set; }
        #endregion

        #region 任务管理
        /// <summary>
        /// 桥梁任务关系表,将桥梁名称也带过来冗余,是否删除：0为未删除,1为已删除,默认为0 
        /// </summary>
        public DbSet<BridgeTaskEntity> BridgeTaskEntitys { get; set; }
        /// <summary>
        /// 任务建议表,是否删除：0为未删除,1为已删除,默认为0 
        /// </summary>
        public DbSet<TaskAdviceEntity> TaskAdviceEntitys { get; set; }
        /// <summary>
        /// 任务主表,1.角色：管养单位；,2.权限：查看所属区域的所有任务数据,新增、编辑、删除
        /// </summary>
        public DbSet<TaskPublishEntity> TaskPublishEntitys { get; set; }
        /// <summary>
        /// 任务类型是“桥梁检测”的子表,是否删除：0为未删除,1为已删除,默认为0 
        /// </summary>
        public DbSet<TaskPublishSubBgecheckEntity> TaskPublishSubBgecheckEntitys { get; set; }
        /// <summary>
        /// 任务类型为“日常巡检”的子表,是否删除：0为未删除,1为已删除,默认为0
        /// </summary>
        public DbSet<TaskPublishSubDailyEntity> TaskPublishSubDailyEntitys { get; set; }
        /// <summary>
        /// 任务类型为“专项评估”的子表,是否删除：0为未删除,1为已删除,默认为0
        /// </summary>
        public DbSet<TaskPublishSubExpertEntity> TaskPublishSubExpertEntitys { get; set; }
        /// <summary>
        /// 任务类型为“完善资料”的子表,是否删除：0为未删除,1为已删除,默认为0 
        /// </summary>
        public DbSet<TaskPublishSubImproveEntity> TaskPublishSubImproveEntitys { get; set; }
        /// <summary>
        /// 桥梁检测子表与病害关系表,是否删除：0为未删除,1为已删除,默认为0
        /// </summary>
        public DbSet<TaskPublishSubModifyDiseaseEntity> TaskPublishSubModifyDiseaseEntitys { get; set; }
        /// <summary>
        /// 任务类型是“维修加固”的子表,是否删除：0为未删除,1为已删除,默认为0
        /// </summary>
        public DbSet<TaskPublishSubModifyEntity> TaskPublishSubModifyEntitys { get; set; }
        /// <summary>
        /// 任务类型为“其它”的子表,是否删除：0为未删除,1为已删除,默认为0 
        /// </summary>
        public DbSet<TaskPublishSubOtherEntity> TaskPublishSubOtherEntitys { get; set; }
        /// <summary>
        /// 任务组
        /// </summary>
        public DbSet<TaskGroupEntity> TaskGroupEntities { get; set; }
        /// <summary>
        /// 任务与第三方单位关系
        /// </summary>
        public DbSet<TaskInstitutionEntity> TaskInstitutionEntities { get; set; }

        #endregion

        #region 养护计划
        /// <summary>
        /// 中长期规划主表,是否删除：0为未删除,1为已删除,默认为0 
        /// </summary>
        public DbSet<MidLongPlanEntity> MidLongPlanEntitys { get; set; }
        /// <summary>
        /// 中长期规划文件表
        /// </summary>
        public DbSet<MidLongPlanFileEntity> MidLongPlanFileEntitys { get; set; }
        /// <summary>
        /// 中长期规划桥梁子表,是否删除：0为未删除,1为已删除,默认为0
        /// </summary>
        public DbSet<MidLongPlanSubEntity> MidLongPlanSubEntitys { get; set; }
        /// <summary>
        /// 中长期时间表
        /// </summary>
        public DbSet<MidLongTimeEntity> MidLongTimeEntitys { get; set; }
        /// <summary>
        /// 工作事项字典表
        /// </summary>
        public DbSet<WorkItemDictionayEntity> WorkItemDictionayEntitys { get; set; }
        /// <summary>
        /// 条件字典表,无,等于,小于等于,大于等于
        /// </summary>
        public DbSet<ConditionDicionaryEntity> ConditionDicionaryEntitys { get; set; }
        /// <summary>
        /// 养护等级维护表
        /// </summary>
        public DbSet<MaintainLevelEntity> MaintainLevelEntitys { get; set; }
        /// <summary>
        /// 周期字典表,日、周、月、季、年,规划类型：,1、日常巡查；2、常规定期；3、结构定期 
        /// </summary>
        public DbSet<PeriodDictionaryEntity> PeriodDictionaryEntitys { get; set; }
        /// <summary>
        /// 年度养护计划自建主表
        /// </summary>
        public DbSet<YearMaintainPlanEntity> YearMaintainPlanEntitys { get; set; }
        /// <summary>
        /// 年度养护计划文件表
        /// </summary>
        public DbSet<YearMaintainPlanFileEntity> YearMaintainPlanFileEntitys { get; set; }
        /// <summary>
        /// 年度养护计划默认规则主表
        /// </summary>
        public DbSet<YearMaintainPlanRuleEntity> YearMaintainPlanRuleEntitys { get; set; }
        /// <summary>
        /// 默认年度规划子项主表
        /// </summary>
        public DbSet<YearPlanItemDefaultEntity> YearPlanItemDefaultEntitys { get; set; }
        /// <summary>
        /// 年度规划子项主表,规划类型：,1、日常巡查；2、常规定期；3、结构定期 
        /// </summary>
        public DbSet<YearPlanItemEntity> YearPlanItemEntitys { get; set; }

        #endregion

        #region 危桥管理
        /// <summary>
        /// 危桥认定来源表
        /// </summary>
        public DbSet<DangerousBridgeCognizanceAssessEntity> DangerousBridgeCognizanceAssessEntitys { get; set; }
        /// <summary>
        /// 危桥处置
        /// </summary>
        public DbSet<DangerousBridgeCognizanceDisposalEntity> DangerousBridgeCognizanceDisposalEntitys { get; set; }
        /// <summary>
        /// 危桥处置措施,措施类型:1限制功能使用 2应急监测3.封闭禁行
        /// </summary>
        public DbSet<DangerousBridgeCognizanceDisposalInfoEntity> DangerousBridgeCognizanceDisposalInfoEntitys { get; set; }
        /// <summary>
        /// 危桥认定,认定方式：日常巡检、定期检测、特殊检测、抗自然灾害能力评估、承载能力评估、独柱墩桥梁横向倾覆安全评
        /// </summary>
        public DbSet<DangerousBridgeCognizanceEntity> DangerousBridgeCognizanceEntitys { get; set; }
        #endregion

        #region 专项评估

        /// <summary>
        /// 专项评估 主表
        /// </summary>
        public DbSet<ThematicEvaluationEntity> ThematicEvaluationEntitys { get; set; }
        /// <summary>
        /// 应急评估
        /// </summary>
        public DbSet<ThematicEvaluationEmergencyEntity> ThematicEvaluationEmergencyEntitys { get; set; }

        /// <summary>
        /// 护栏防撞能力专项评估
        /// </summary>
        public DbSet<ThematicEvaluationGuardrailEntity> ThematicEvaluationGuardrailEntitys { get; set; }
        /// <summary>
        /// 桥梁敷设设施安全评估
        /// </summary>
        public DbSet<ThematicEvaluationLayingEntity> ThematicEvaluationLayingEntitys { get; set; }
        /// <summary>
        /// 承载能力专项评估
        /// </summary>
        public DbSet<ThematicEvaluationLoadBearingEntity> ThematicEvaluationLoadBearingEntitys { get; set; }
        /// <summary>
        /// 超限荷载过桥安全评估
        /// </summary>
        public DbSet<ThematicEvaluationLoadEntity> ThematicEvaluationLoadEntitys { get; set; }
        /// <summary>
        /// 抗自然灾害能力评估
        /// </summary>
        public DbSet<ThematicEvaluationNatureEntity> ThematicEvaluationNatureEntitys { get; set; }
        /// <summary>
        /// 其他专项评估
        /// </summary>
        public DbSet<ThematicEvaluationOtherEntity> ThematicEvaluationOtherEntitys { get; set; }
        /// <summary>
        /// 独柱墩桥梁横向倾覆安全评估
        /// </summary>
        public DbSet<ThematicEvaluationOverturnEntity> ThematicEvaluationOverturnEntitys { get; set; }
        /// <summary>
        /// 安全保护区域内外部作业对桥梁结构影响评估
        /// </summary>
        public DbSet<ThematicEvaluationStructureEntity> ThematicEvaluationStructureEntitys { get; set; }

        #endregion

        #region 数据字典
        //BgeNewDictionaryEntity
        public DbSet<BgeNewDictionaryEntity> BgeNewDictionaryEntitys { get; set; }//没有提交,报错先注释，自己添加后打开
        #endregion

        #region 通讯录
        public DbSet<UserConnectioninfoEntity> UserConnectioninfoEntitys { get; set; }
        public DbSet<UserConnectionPhoneEntity> UserConnectionPhoneEntitys { get; set; }
        #endregion

        #region 各个市级统计端
        public DbSet<ReportBridgeDistributionEntity> reportBridgeDistributionEntities { get; set; }
        public DbSet<ReportHeadTopEntity> ReportHeadTopEntitys { get; set; }
        public DbSet<ReportJobRatingRankingEntity> reportJobRatingRankingEntities { get; set; }
        public DbSet<ReportSystemUtilizationRankingEntity> reportSystemUtilizationRankingEntities { get; set; }
        #endregion

        /// <summary>
        /// EF core 构造函数
        /// </summary>
        /// <param name="options"></param>
        public BridgeServiceDbContext(DbContextOptions<BridgeServiceDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //过滤
            builder.Entity<InspectionsInfo>().Ignore(it => it.SysUserDetails).Ignore(it => it.InspectionDamage).Ignore(it => it.InspectionsInfoDisease).Ignore(it => it.InsperData);
            base.OnModelCreating(builder);
        }
    }
}
