多目录进行压缩备份,进行定时任务
业务逻辑：先将来源目录进行复制出一份临时文件夹，然后对该临时文件夹进行压缩打包，打包完成后删除临时文件夹，复制压缩包到目标路径，删除本地压缩包;
使用管理员方式执行 install.bat 可安装为windows 服务进行，系统重启会自动开启.
因程序需要对指定文件目录及文件进行读写，故360 或其它防火墙杀毒软件会进行拦截，请将本程序加入白名单

程序的安装及卸载：用管理员模式打开cmd ，并定位到程序所在目录

    - 安装
        BackupsZip.exe install
        BackupsZip.exe start

    - 卸载
        BackupsZip.exe stop
        BackupsZip.exe uninstall



程序配置文件 config.json 说明：(可以记事本打开进行编辑)

[
  {
    "SourcePath": "D:\\temp\\SourcePath", /* 需要备份的目录 */
    "TargetPath": "D:\\temp\\TargetPath", /* 备份后存放目录 */
    "FileFormat": "yyyyMMddhhmm", /* 文件名格式如：202007071604 */
    "SyncOne": true, /* 是否立即执行一次 */
    "IncludeSubdir": true, /* 是否包含子目录 */
    "ExecutionTime": "03:00:00", /*自动执行时间 时:分:秒,默认凌晨3点 */
    "ZipLevel": 9, /*压缩等级 0-9 越多压缩越小*/
    "FilterType": "*.*" /*文件类型*/
  },
  {
    "SourcePath": "D:\\temp\\SourcePath2", /* 需要备份的目录 */
    "TargetPath": "D:\\temp\\TargetPath", /* 备份后存放目录 */
    "FileFormat": "yyyyMMddhhmmss", /* 备份文件名:年月日时分秒 */
    "SyncOne": true, /* 是否立即执行一次 */
    "IncludeSubdir": true, /* 是否包含子目录 */
    "ExecutionTime": "00:15:00", /*自动执行时间 时分 */
    "ZipLevel": 9, /*压缩等级 0-9 越多压缩越小*/
    "FilterType": "*.*" /*文件类型*/
  }
]