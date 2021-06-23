terraform{
    required_providers {
        azurerm = {
            source = "hashicorp/azurerm"
            version = "~>2.31.1"
        }

    }
        
}

# config details for az terraform provider

provider "azurerm" {
    features{}
}

# creates resource group

resource "azurerm_resource_group" "rg" {
    name = ckb-proj-two
    location = "uksouth"
    tags = {
        environment = "dev"
        source = "Terraform"
        project = true 
    }
}