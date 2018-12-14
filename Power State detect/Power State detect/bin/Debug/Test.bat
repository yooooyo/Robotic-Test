@echo off
SET APP_LOC=%~dp0
SET APP="IOT Robot.exe"
%APP_LOC%/%APP% tap baseline
%APP_LOC%/%APP% tap tap
%APP_LOC%/%APP% s3 10
%APP_LOC%/%APP% tap tap
%APP_LOC%/%APP% s4 20
%APP_LOC%/%APP% tap tap
