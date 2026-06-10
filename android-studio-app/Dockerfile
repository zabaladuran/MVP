FROM gradle:8.5-jdk17 AS builder

ARG PHP_URL=http://10.0.2.2:8000

ENV ANDROID_SDK_ROOT=/opt/android-sdk

# Instalar dependencias y Android SDK command-line tools
RUN apt-get update && apt-get install -y --no-install-recommends wget unzip && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /tmp
RUN wget -q https://dl.google.com/android/repository/commandlinetools-linux-11076708_latest.zip && \
    unzip -q commandlinetools-linux-11076708_latest.zip && \
    rm commandlinetools-linux-11076708_latest.zip && \
    mkdir -p ${ANDROID_SDK_ROOT}/cmdline-tools && \
    mv cmdline-tools ${ANDROID_SDK_ROOT}/cmdline-tools/latest

ENV PATH=${PATH}:${ANDROID_SDK_ROOT}/cmdline-tools/latest/bin:${ANDROID_SDK_ROOT}/platform-tools

# Aceptar licencias e instalar componentes del SDK
RUN yes | sdkmanager --licenses > /dev/null 2>&1 && \
    sdkmanager "platform-tools" "platforms;android-34" "build-tools;34.0.0" > /dev/null 2>&1

WORKDIR /app
COPY . .

# Eliminar local.properties (apunta a SDK local de otra máquina)
RUN rm -f local.properties

# Reemplazar URL hardcodeada en el código fuente
RUN sed -i "s|http://[0-9.]*:[0-9]*|${PHP_URL}|g" app/src/main/java/com/duran/appmvp/MainActivity.kt

# Compilar APK release
RUN gradle assembleRelease --no-daemon

# Stage 2: servir el APK
FROM python:3.11-slim
COPY --from=builder /app/app/build/outputs/apk/release/app-release.apk /usr/share/apk/
WORKDIR /usr/share/apk
CMD ["python3", "-m", "http.server", "5000"]
