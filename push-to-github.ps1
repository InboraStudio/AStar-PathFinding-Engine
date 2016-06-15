#!/usr/bin/env pwsh

# GitHub SSH Push Script for AStar-PathFinding-Engine
# This script will push your project to GitHub using SSH

param(
    [Parameter(Mandatory=$true)]
    [string]$GitHubUsername
)

$projectPath = "d:\Github Data\AStar-PathFinding-Engine"
$repoName = "AStar-PathFinding-Engine"
$remoteUrl = "git@github.com:$GitHubUsername/$repoName.git"

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "GitHub SSH Push Script" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Check if git is installed
Write-Host "Checking git installation..." -ForegroundColor Yellow
if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
    Write-Host "ERROR: Git is not installed" -ForegroundColor Red
    exit 1
}
Write-Host "✓ Git found" -ForegroundColor Green

# Check SSH key
Write-Host "Checking SSH key..." -ForegroundColor Yellow
$sshKey = "$env:USERPROFILE\.ssh\id_rsa"
if (-not (Test-Path $sshKey)) {
    Write-Host "WARNING: SSH key not found at $sshKey" -ForegroundColor Yellow
    Write-Host "Generating SSH key..." -ForegroundColor Yellow
    ssh-keygen -t rsa -b 4096 -f "$env:USERPROFILE\.ssh\id_rsa" -N ""
    Write-Host "✓ SSH key generated" -ForegroundColor Green
} else {
    Write-Host "✓ SSH key found" -ForegroundColor Green
}

# Navigate to project
Write-Host "Navigating to project..." -ForegroundColor Yellow
Set-Location $projectPath
Write-Host "✓ Project path: $projectPath" -ForegroundColor Green

# Check if remote already exists
Write-Host "Checking git remote..." -ForegroundColor Yellow
$existingRemote = git remote get-url origin 2>$null
if ($existingRemote) {
    Write-Host "Remote already exists: $existingRemote" -ForegroundColor Yellow
    Write-Host "Removing existing remote..." -ForegroundColor Yellow
    git remote remove origin
}

# Add SSH remote
Write-Host "Adding SSH remote..." -ForegroundColor Yellow
git remote add origin $remoteUrl
Write-Host "✓ Remote added: $remoteUrl" -ForegroundColor Green

# Show instructions
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "NEXT STEPS:" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "1. Go to https://github.com/settings/keys" -ForegroundColor White
Write-Host "2. Click 'New SSH key'" -ForegroundColor White
Write-Host "3. Copy your public key from this file:" -ForegroundColor White
Write-Host "   $env:USERPROFILE\.ssh\id_rsa.pub" -ForegroundColor Yellow
Write-Host ""
Write-Host "   Display public key with:" -ForegroundColor White
Write-Host "   Get-Content $env:USERPROFILE\.ssh\id_rsa.pub | Set-Clipboard" -ForegroundColor Yellow
Write-Host ""
Write-Host "4. Paste it on GitHub with title: 'SSH Key'" -ForegroundColor White
Write-Host "5. Test SSH connection:" -ForegroundColor White
Write-Host "   ssh -T git@github.com" -ForegroundColor Yellow
Write-Host ""
Write-Host "6. Once SSH key is added, run:" -ForegroundColor White
Write-Host "   cd '$projectPath'" -ForegroundColor Yellow
Write-Host "   git push -u origin main" -ForegroundColor Yellow
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Test SSH connection
Write-Host "Testing SSH connection to GitHub..." -ForegroundColor Yellow
$sshTest = ssh -T git@github.com 2>&1
if ($sshTest -match "successfully authenticated") {
    Write-Host "✓ SSH connection successful!" -ForegroundColor Green
    Write-Host ""
    Write-Host "Pushing to GitHub..." -ForegroundColor Yellow
    git push -u origin main
    if ($LASTEXITCODE -eq 0) {
        Write-Host "✓ Successfully pushed to GitHub!" -ForegroundColor Green
        Write-Host "Repository: https://github.com/$GitHubUsername/$repoName" -ForegroundColor Cyan
    } else {
        Write-Host "ERROR: Failed to push" -ForegroundColor Red
    }
} else {
    Write-Host "⚠ SSH not yet authenticated. Please add your public key to GitHub first." -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Public key location: $env:USERPROFILE\.ssh\id_rsa.pub" -ForegroundColor Yellow
}
