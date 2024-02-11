print('Start #################################################################');
db = db.getSiblingDB('message-db');

db.createCollection('messages');

print('END ###################################################################');