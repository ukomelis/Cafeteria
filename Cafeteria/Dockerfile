FROM node:16

WORKDIR /src/app/

RUN npm install -g react-scripts

RUN chown -Rh node:node /src/app

USER node

EXPOSE 4200

CMD [ "sh", "-c", "npm install && npm run start" ]