
pipeline {
    agent any

    options {
        timestamps()
    }

    environment {
        BUILD_CONFIGURATION = 'Release'
    }

    stages {

        stage('Checkout') {
            steps {
                echo 'Downloading Employee Management source code'
                checkout scm
            }
        }

        stage('Check .NET SDK') {
            steps {
                bat 'dotnet --version'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore EmployeeManagement.sln'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build EmployeeManagement.sln --configuration %BUILD_CONFIGURATION% --no-restore'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test EmployeeManagement.sln --configuration %BUILD_CONFIGURATION% --no-build'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish src\\EmployeeManagement.Api\\EmployeeManagement.Api.csproj --configuration %BUILD_CONFIGURATION% --no-build --output publish'
            }
        }

        stage('Archive Artifacts') {
            steps {
                archiveArtifacts artifacts: 'publish/**', fingerprint: true
            }
        }
    }

    post {
        success {
            echo 'Employee Management CI Pipeline completed successfully!'
        }

        failure {
            echo 'Pipeline failed. Please check the Jenkins console output.'
        }
    }
}
