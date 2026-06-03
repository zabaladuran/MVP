FROM android:api-30

# Instalar herramientas necesarias
RUN apt-get update && apt-get install -y \
    openjdk-11-jdk \
    curl \
    && rm -rf /var/lib/apt/lists/*

# Establecer variables de entorno
ENV ANDROID_HOME=/opt/android-sdk-linux
ENV PATH=${PATH}:${ANDROID_HOME}/tools:${ANDROID_HOME}/platform-tools

# Variables de conexión a la base de datos
ENV DB_HOST=mysql
ENV DB_PORT=3306
ENV DB_NAME=mvp_db
ENV DB_USER=mvp_user
ENV DB_PASSWORD=mvp_password

WORKDIR /app

# Copiar archivos del proyecto
COPY . .

# Crear directorio para el emulador
RUN mkdir -p /opt/emulator

EXPOSE 5037 8080

# Comando por defecto
CMD ["bash"]
