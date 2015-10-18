# HFramework

## Client
asp.net 4.0

## Service
Wcf4.0 restful

## DB
支持 sqlserver / mysql
新增配置文件中选项，添加对应驱动类即可.

# web.config
*.config .....
* 系统启动项
```
<!-- 设置网站启动时和网站关闭时自动执行的任务的配置文件路径， 支持绝对路径或相对于WebHost跟目录的路径-->
<add key="AutorunConfigPath" value="Configuration\Autorun.config"/>
```
* WCF token
```
<!-- ProjectName：项目名称
     InteractionKey：加密字符串
     客户端与REST服务端进行交互时加密匹配 -->
<add key="ProjectName" value="HO"/>
<add key="InteractionKey" value="Henry"/>
```
* 文件监控
web.config
  
```
<!-- 文件监控配置 -->
  <add key="FileWatcherConfigPath" value="Configuration\FileWatcher.config"/>
```
