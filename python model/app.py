from fastapi import FastAPI ,Depends , HTTPException
from cachetools import TTLCache

import numpy as np
from fastapi.middleware.cors import CORSMiddleware

app = FastAPI()
origins = ["http://localhost",
           "http://localhost:5500",
           "http://yourfrontenddomain.com"]

app.add_middleware(
    CORSMiddleware,
    allow_origins = origins,
    allow_credentials = True,
    allow_methods = ["GET,POST"],
    allow_headers = ["*"],
)

cache = TTLCache(maxsize=1,ttl=60)
class PreprocessDataDependency:
    def __init__(self,cache):
        self.cache = cache
processed_data_dependency = PreprocessDataDependency(cache)

@app.post('/predict')
def predict(data:dict):
    data1 = data["input"]
    processed_data = {"result":data1}

    processed_data_dependency.cache["processed_data"] = processed_data
    return {"message":"Data processed successfully"}
@app.get('/result')
def result(cache:TTLCache = Depends(lambda:processed_data_dependency.cache)):
    data = cache.get("processed_data")
    a=2
    if data is None:
        raise HTTPException(status_code=404,detail="No data available")
    return {'result':data['result']}