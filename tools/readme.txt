一、环境要求
1.windows 7 or 8 
2.net4.0+
3.mysql5.05

二、创建11选5彩种数据库（目前只研究江西，广东，山东，重庆四地的11选5）
注：所有的数据库应该是InnoDB格式，字符集为:utf8
1.先把docs/database/mysql/InitDB.rar解压
2.创建lottery数据库，然后导入docs/database/mysql/InitDB/lottery.sql
  该数据库表中保存相关配置数据，如彩种类型启用，分析维护启用。
3.创建lotterychongq115,lotteryguangd115,lotteryjiangx115,lotteryshand115
  然后从docs/database/mysql/InitDB导入对应的sql语句。目前数据只更新到20130707号
4.运行tools/respans.bat初始化所有数据遗漏情况

三、tools应用说明

1.lottery.exe是分析主程,可以用来查看相关数据分析情况
2.lottery.service.exe是自动下载数据的服务程序，如果需要自动下载数据可以把它安装成windows服务项
  动install.bat安装成服务，uninstall.bat删除该服务(注意：如果以管理员角色才能安装成功)
3.down.bat 是手动下载数据的命令，如果你不希望安装lottery.service话，可以每隔一段时手动运行该命令来下载数据。
4.respan.bat 初始化所有数据遗漏情况命令，在第一次使用该程序时或全部重新计算遗漏情况时运行。
5.span.bat 计算遗漏命令，如果程序下载了新数据，需要查看新的遗漏情况，需要运行该命令。