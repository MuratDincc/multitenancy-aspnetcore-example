# Create app directory
RUN mkdir -p /Users/murat.dinc/Desktop/Projects/MultiTenantAspNetCore/usr/src/app
WORKDIR /Users/murat.dinc/Desktop/Projects/MultiTenantAspNetCore/usr/src/app

# Copy initialization scripts
COPY . /Users/murat.dinc/Desktop/Projects/MultiTenantAspNetCore/usr/src/app

# Grant permissions for the run-initialization script to be executable
RUN chmod +x /Users/murat.dinc/Desktop/Projects/MultiTenantAspNetCore/usr/src/app/run-initialization.sh

# Expose port 1433 in case accesing from other container
EXPOSE 1433

# Run Microsoft SQl Server and initialization script (at the same time)
# Note: If you want to start MsSQL only (without initialization script) you can comment bellow line out, CMD entry from base image will be taken
CMD /bin/bash ./entrypoint.sh