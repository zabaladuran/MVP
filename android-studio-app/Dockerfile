FROM gradle:8.5-jdk17 AS builder

ARG PHP_URL=http://10.0.2.2:8000

ENV ANDROID_SDK_ROOT=/opt/android-sdk
ENV ANDROID_HOME=/opt/android-sdk

# Instalar dependencias
RUN apt-get update && apt-get install -y --no-install-recommends wget unzip && \
    rm -rf /var/lib/apt/lists/*

# Descargar Android SDK command-line tools
RUN wget -q https://dl.google.com/android/repository/commandlinetools-linux-11076708_latest.zip -O /tmp/cmdline-tools.zip && \
    unzip -q /tmp/cmdline-tools.zip -d /tmp/ && \
    rm /tmp/cmdline-tools.zip && \
    mkdir -p ${ANDROID_SDK_ROOT}/cmdline-tools && \
    mv /tmp/cmdline-tools ${ANDROID_SDK_ROOT}/cmdline-tools/latest

ENV PATH=${PATH}:${ANDROID_SDK_ROOT}/cmdline-tools/latest/bin:${ANDROID_SDK_ROOT}/platform-tools

# Aceptar licencias e instalar SDK components
RUN yes | sdkmanager --licenses
RUN sdkmanager "platform-tools" "platforms;android-34" "build-tools;34.0.0"

WORKDIR /app
COPY . .

# Eliminar archivo local.properties (apunta a SDK de otra máquina)
RUN rm -f local.properties && chmod +x gradlew

# Reemplazar URL en el código fuente
RUN sed -i "s|http://[0-9.]*:[0-9]*|${PHP_URL}|g" app/src/main/java/com/duran/appmvp/MainActivity.kt

# Ver URL configurada (debug)
RUN echo "PHP_URL configurado: ${PHP_URL}" && \
    grep "loadUrl" app/src/main/java/com/duran/appmvp/MainActivity.kt

# Compilar APK debug (no necesita firma)
RUN ./gradlew assembleDebug --no-daemon --stacktrace

# Verificar que el APK se generó
RUN ls -la app/build/outputs/apk/debug/ || echo "No se encontró APK"

# Stage final: servir el APK
FROM python:3.11-slim
COPY --from=builder /app/app/build/outputs/apk/debug/app-debug.apk /apk/app-mvp.apk
WORKDIR /apk
CMD ["python3", "-m", "http.server", "5000"]
