# config for terraform providers
terraform{
    required_providers {
        azurerm = {
            source = "hashicorp/azurerm"
            version = "~>2.46.0"
        }

    }
        
}
locals {
    prefix = "ckb"
    location ="uksouth"
}
variable "project_name" {
    default = "superherogen"
}
provider "azurerm" {
    features{}
}

# create resource group
resource "azurerm_resource_group" "rg" {
    name = "${local.prefix}-${var.project_name}-rg"
    location = "${local.location}"
    tags = {
        environment = "dev"
        source = "Terraform"
        project = "true" 
    }
}
# create service plan
resource "azurerm_app_service_plan" "sp" {
    name = "${local.prefix}-${var.project_name}-app-svc"
    kind = "Linux"
    sku{
        tier = "Basic"
        size = "B1"
    }
    reserved = true
    resource_group_name = azurerm_resource_group.rg.name
    location = azurerm_resource_group.rg.location
}

#config azure app services
resource "azurerm_app_service" "svc1" {
    name = "${local.prefix}-${var.project_name}-frontend"
    resource_group_name= azurerm_resource_group.rg.name
    location = azurerm_resource_group.rg.location
    app_service_plan_id = azurerm_app_service_plan.sp.id

    site_config {
    dotnet_framework_version = "v5.0"
    scm_type = "LocalGit"
    }

    app_settings = {
        frontendServiceURL: "https://ckb-superherogen-frontend.azurewebsites.net"
        WEBSITES_WEBDEPLOY_USE_SCM = "false"
    }
    tags = {
        project = true
    }
}
resource "azurerm_app_service" "svc2" {
    name = "${local.prefix}-${var.project_name}-firstnames"
    resource_group_name= azurerm_resource_group.rg.name
    location = azurerm_resource_group.rg.location
    app_service_plan_id = azurerm_app_service_plan.sp.id

    site_config {
    dotnet_framework_version = "v5.0"
    scm_type = "LocalGit"
    }
     app_settings = {
        firstnamesServiceURL: "https://ckb-superherogen-firstnames.azurewebsites.net"
        WEBSITES_WEBDEPLOY_USE_SCM = "false"
    }
    tags = {
        project = true
    }
}
resource "azurerm_app_service" "svc3" {
    name = "${local.prefix}-${var.project_name}-secondnames"
    resource_group_name= azurerm_resource_group.rg.name
    location = azurerm_resource_group.rg.location
    app_service_plan_id = azurerm_app_service_plan.sp.id
    
    site_config {
    dotnet_framework_version = "v5.0"
    scm_type = "LocalGit"
    }
     app_settings = {
        secondnamesServiceURL: "https://ckb-superherogen-secondnames.azurewebsites.net"
        WEBSITES_WEBDEPLOY_USE_SCM = "false"
    }
    tags = {
        project = true
    }
}
resource "azurerm_app_service" "sv4" {
    name = "${local.prefix}-${var.project_name}-merge"
    resource_group_name= azurerm_resource_group.rg.name
    location = azurerm_resource_group.rg.location
    app_service_plan_id = azurerm_app_service_plan.sp.id

    site_config {
    dotnet_framework_version = "v5.0"
    scm_type = "LocalGit"
    }
     app_settings = {
        mergeServiceURL: "https://ckb-superherogen-merge.azurewebsites.net"
        WEBSITES_WEBDEPLOY_USE_SCM = "false"
    }
    tags = {
        project = true
    }
}
