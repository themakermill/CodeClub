import urllib
import urllib.request
import json

def getProduct(prodID):
  
  url_1='http://localhost:61482/'
  url_2='api/products/' + str(prodID)	
 
  request = urllib.request.Request(url_1 + url_2)
  response = urllib.request.urlopen(request)
  data = json.loads(response.read().decode('utf-8'))

  print(data)
  print (str(data['Name']))

def getProducts():
  
  url_1='http://localhost:61482/'
  url_2='api/products/'	
 
  request = urllib.request.Request(url_1 + url_2)
  response = urllib.request.urlopen(request)
  data = json.loads(response.read().decode('utf-8'))

  print(data)

getProduct(1)
getProducts()

