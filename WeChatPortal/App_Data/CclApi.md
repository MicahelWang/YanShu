API说明
===
本API使用post方法接收参数，返回格式为json。如果成功，返回格式为：

	{
		"static":"OK",
		"value":"123.456"	
	}
若失败，则返回：

	{
		"static":"Error",
		"message":"XXXXX"
	}	


#### 1. beta.jiajiabaoxian.com/api/ccl3
危疾終身保計劃（保诚）计算器

	{
	测试样例
	"gender":"m",
	"age":1, 
	"smokingStatus":"n", 
	"currency":"USD", 
	"sumAssured":30000.0,
	"PaymentTerms":10,
	"payment_mode":"year"
    }
##### 说明
	{
	"gender":为字符"m"/"f",
	"age":投保年龄，int、str均可范围[1,65],
	"smokingStatus":吸烟状态，str "s" or "n",
	"sumAssured":投保金额 USD[15000,1200000],HKD[120000,9600000],
	"PaymentTerms": "5","10","15","25","until55","until65"           //付款方式,5年，10年，15年，25年，25-55年，55-65年,
	"payment_mode":	"year","half","quarter","month"			//付款方式,年付，半年付，季付，月付
	}
#### 2. beta.jiajiabaoxian.com/api/pls
理想人生計劃（保诚）计算器

	{
	测试样例
	"gender":"m",
	"age":19, 
	"smokingStatus":"ns", 
	"currency":"usd", 
	"sumAssured":30000.0,
	"PaymentTerms":"5ys",
    }
##### 说明
	{
	"gender":性别"m"/"f",
	"age":[19,65],大部分在这个区间，个别情况没有参数。 
	"smokingStatus":"ns"/"s", 
	"currency":"usd"/"rmb"/"hkd", 小写字符串
	"sumAssured":usd[0,+∞],rmb[0,+∞],hkd[0，+∞],
	"PaymentTerms":"5ys"五年,"sin"一次付清,"10ys"10年,"15ys","20ys","30ys","until85","until60","until65"
    }
#### 3. beta.jiajiabaoxian.com/api/egs_value
egs现金价值
隽陞（保诚）计算器

	{
	"age":30,  
	"sumAssured":"100w",
	"PaymentTerms":"5ys",
    }
#####说明

	{
	"age":30, [5,95],都为5的整数倍
	"sumAssured":"5w","10w","20w","100w","50w",付款方式不支持5万，会返回报错
	"PaymentTerms":"5ys","10ys","sin" 五年，十年，一次付清
    }
#### 4. beta.jiajiabaoxian.com/api/egs_rate
egs现金本金赔率
隽陞（保诚）计算器

	{
	"age":30,  
	"sumAssured":"100w",
	"PaymentTerms":"5ys",
    }
#####说明

	{
	"age":30, [5,95],都为5的整数倍
	"sumAssured":"5w","10w","20w","100w","50w",付款方式不支持5万，会返回报错
	"PaymentTerms":"5ys","10ys","sin" 五年，十年，一次付清
    }
#### 5. beta.jiajiabaoxian.com/api/bpp_value
bpp保证现金价值
充裕未來（友邦AIA）计算器
	
	{
	"age":10,  
	"sumAssured":"100w",
	"PaymentTerms":"5ys",
    }
#####说明

	{
	"age":30, [5,95],都为5的整数倍
	"sumAssured":"1w","2w","10w","20w","100w"
	"PaymentTerms":"5ys","10ys","sin" 五年，十年，一次付清
    }
	
#### 6. beta.jiajiabaoxian.com/api/bpp_rate
bpp现金价值总值
充裕未來（友邦AIA）计算器

	{
	"age":10,  
	"sumAssured":"100w",
	"PaymentTerms":"5ys",
    }
#####说明

	{
	"age":30, [5,95],都为5的整数倍
	"sumAssured":"1w","2w","10w","20w","100w"
	"PaymentTerms":"5ys","10ys" 五年，十年
    }
#### 7. beta.jiajiabaoxian.com/api/bpp_baserate
bpp本金翻倍率
充裕未來（友邦AIA）计算器
	
	{
	"age":10,  
	"sumAssured":"100w",
	"PaymentTerms":"5ys",
    }
#####说明

	{
	"age":30, [5,95],都为5的整数倍
	"sumAssured":"1w","2w","10w","20w","100w"
	"PaymentTerms":"5ys","10ys" 五年，十年
    }
	
#### 8. beta.jiajiabaoxian.com/api/al2
裕滿人生計劃（友邦AIA）计算器
	
	{
	"gender":"m",
	"age":1, 
	"smokingStatus":"ns", 
	"currency":"usd", 
	"sumAssured":30000.0,
	"PaymentTerms":"sin",
    }
#####说明

	{
	"gender":"m",
	"age":[0,75], 
	"smokingStatus":"ns", "s"
	"currency":"usd","hkd" 
	"sumAssured":30000.0,hkd[75000,+∞],usd[10000,+∞]
	"PaymentTerms":"sin","5ys","10ys","18ys","25ys",付款年限，一次付清，5年...
	
    }
	
#### 9. beta.jiajiabaoxian.com/api/pe
加裕倍安保（友邦AIA）计算器
	
	{
	"gender":"m",
	"age":1, 
	"smokingStatus":"ns", 
	"currency":"usd", 
	"sumAssured":30000.0,
	"PaymentTerms":"18ys",
    }
#####说明

	{
	"gender":"m",
	"age":[0,65], 有些付款方式在某些年龄没有返回值
	"smokingStatus":"ns", "s"
	"currency":"usd","hkd" 
	"sumAssured":30000.0,hkd[75000,+∞],usd[10000,+∞]
	"PaymentTerms":"10ys","18ys","25ys",付款年限，10年...
	
    }
	
#### 10. beta.jiajiabaoxian.com/api/plj
守護一生保障計劃（保诚）计算器

	{
	"gender":"m",
	"age":1, 
	"smokingStatus":"ns", 
	"currency":"usd", 
	"sumAssured":300000.0,
	"PaymentTerms":"5ys",
    }
#####说明

	{
	"gender":"m",
	"age":[1,18]
	"smokingStatus":"ns", "s"
	"currency":"usd","hkd" 
	"sumAssured":30000.0,hkd[800000,+∞],usd[100000,+∞],rmb[600000,+∞]
	"PaymentTerms":"5","10ys","15ys",付款年限，10年...
	
    }
	
#### 11. beta.jiajiabaoxian.com/api/fl3
愛無憂長享計劃3(Forever Love III）（友邦AIA）计算器

	{
	"gender":"f",
	"age":54, 
	"sumAssured":30000,
	"PaymentTerms":"15ys",
    }

#####说明

	{
	"gender":"m","f"
	"age":[0,55]
	"sumAssured":usd[5000,+∞]
	"PaymentTerms":"6ys","10ys","15ys","20ys" 付款年限，10年...
	
    }

