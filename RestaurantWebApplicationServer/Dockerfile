FROM openjdk:8-jdk-alpine

ENV dev.payu.auth.url=https://secure.snd.payu.com/pl/standard/user/oauth/authorize \
    dev.payu.auth.grant_type=client_credentials \
    dev.payu.auth.clientId=386563 \
    dev.payu.auth.clientsecret=9977caad34e7e894a2806cee13325367 \
    security.oauth2.client.client-id=first-client \
    security.oauth2.client.client-secret=noonewilleverguess

ARG JAR_FILE=target/*.jar
COPY ${JAR_FILE} app.jar
ENTRYPOINT ["java","-jar","/app.jar"]

