using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade
{
    /// <summary>
    /// 页面的Url Alias
    /// </summary>
    public enum PageAlias
    {
        
        /// <summary>
        /// 系统用户
        /// </summary>
        SystemUser,
        /// <summary>
        /// 系统用户维护
        /// </summary>
        SystemUserMaintain,
        /// <summary>
        /// 系统用户信息修改
        /// </summary>
        UserInfo,
        /// <summary>
        /// 系统用户与角色关联
        /// </summary>
        SystemUserRoleMapping,
        /// <summary>
        /// 系统错误日志
        /// </summary>
        ErrorLog,
        /// <summary>
        /// 系统错误日志明细
        /// </summary>
        ErrorLogDetails,        
        /// <summary>
        /// 权限管理
        /// </summary>
        SystemUserPrivilege,
        /// <summary>
        /// 权限维护
        /// </summary>
        SystemUserPrivilegeMaintain,
        /// <summary>
        /// 角色管理
        /// </summary>
        SystemUserRole,
        /// <summary>
        /// 角色维护
        /// </summary>
        SystemUserRoleMaintain,        
        /// <summary>
        /// 系统登录
        /// </summary>
        Login,
        /// <summary>
        /// 团队活动
        /// </summary>
        TeamBuilding,
        /// <summary>
        /// 登录首页
        /// </summary>
        Index,
        /// <summary>
        /// 管理制度
        /// </summary>
        Management,
        /// <summary>
        /// 管理制度维护
        /// </summary>
        ManagementMaintain,
        /// <summary>
        /// 收费标准
        /// </summary>
        Charge,
        /// <summary>
        /// 收费标准维护
        /// </summary>
        ChargeMaintain,
        /// <summary>
        /// 会员活动一览
        /// </summary>
        ClubMembers,
        /// <summary>
        /// 会员活动维护
        /// </summary>
        ClubMembersMaintain,
        /// <summary>
        /// 会员活动管理
        /// </summary>
        ClubMembersManager
    }
}
