#!/usr/bin/python
# coding:utf-8
import requests
url = 'http://beta.jiajiabaoxian.com/api/plj'
# data_fl3={
# "gender":"f",
# "age":54, 
# "sumAssured":150001,
# "PaymentTerms":"6ys",
#     }

# data_ccl={
# "gender":"m",
# "age":1, 
# "smokingStatus":"n", 
# "currency":"USD", 
# "sumAssured":30000.0,
# "PaymentTerms":"Until65",
# "payment_mode":"year"
#     }

# data_pls={
# "gender":"m",
# "age":19, 
# "smokingStatus":"ns", 
# "currency":"rmb", 
# "sumAssured":30000.0,
# "PaymentTerms":"5ys",
#     }


# data_egs_value={
# "age":30,  
# "sumAssured":"100w",
# "PaymentTerms":"5ys",
#     }

# data_egs_rate={
# "age":30,  
# "sumAssured":"100w",
# "PaymentTerms":"5ys",
#     }

# data_bpp_value={
# "age":10,  
# "sumAssured":"100w",
# "PaymentTerms":"5ys",
#     }
# data_al2={
# "gender":"m",
# "age":1, 
# "smokingStatus":"ns", 
# "currency":"usd", 
# "sumAssured":30000.0,
# "PaymentTerms":"sin",
#     }
# data_pe={
# "gender":"m",
# "age":1, 
# "smokingStatus":"ns", 
# "currency":"usd", 
# "sumAssured":30000.0,
# "PaymentTerms":"18ys",
#     }

data_plj={
"gender":"m",
"age":1, 
"smokingStatus":"ns", 
"currency":"usd", 
"sumAssured":300000.0,
"PaymentTerms":"5ys",
    }
r = requests.post(url, data=data_plj)
print r.content














