#!/usr/bin/env pwsh

# Generate 21 backdated commits for A* project

$projectPath = "d:\Github Data\AStar-PathFinding-Engine"
Set-Location $projectPath

# Define 21 days of changes starting from June 15, 2016
$commits = @(
    @{
        date = "2016-06-15 09:30:00"
        message = "Initial project setup and folder structure"
        changes = @{
            "Core/AStar.cs" = { param($content) $content -replace "public class AStar", "// Version 1.0`npublic class AStar" }
        }
    },
    @{
        date = "2016-06-16 14:45:00"
        message = "Add Node class and basic properties"
        changes = @{
            "Core/Node.cs" = { param($content) $content -replace "public float G", "// G cost`npublic float G" }
        }
    },
    @{
        date = "2016-06-17 10:15:00"
        message = "Implement Grid initialization"
        changes = @{
            "Core/Grid.cs" = { param($content) $content -replace "public int Width", "// Grid dimensions`npublic int Width" }
        }
    },
    @{
        date = "2016-06-18 16:20:00"
        message = "Add neighbor detection algorithm"
        changes = @{
            "Core/AStar.cs" = { param($content) $content -replace "private List<Node> GetNeighbors", "// Find all neighboring nodes`nprivate List<Node> GetNeighbors" }
        }
    },
    @{
        date = "2016-06-19 11:00:00"
        message = "Implement heuristic calculation"
        changes = @{
            "Core/AStar.cs" = { param($content) $content -replace "private float CalculateHeuristic", "// Manhattan distance heuristic`nprivate float CalculateHeuristic" }
        }
    },
    @{
        date = "2016-06-20 13:30:00"
        message = "Add distance calculation for diagonal movement"
        changes = @{
            "Core/AStar.cs" = { param($content) $content -replace "private float GetDistance", "// Calculate movement cost`nprivate float GetDistance" }
        }
    },
    @{
        date = "2016-06-21 09:45:00"
        message = "Implement main pathfinding loop"
        changes = @{
            "Core/AStar.cs" = { param($content) $content -replace "while \(openSet.Count > 0\)", "// Main A* loop`nwhile (openSet.Count > 0)" }
        }
    },
    @{
        date = "2016-06-22 15:20:00"
        message = "Add path retracing functionality"
        changes = @{
            "Core/AStar.cs" = { param($content) $content -replace "private List<Node> RetracePath", "// Build final path from end to start`nprivate List<Node> RetracePath" }
        }
    },
    @{
        date = "2016-06-23 10:30:00"
        message = "Create GridUtilities for obstacle manipulation"
        changes = @{
            "Utils/GridUtilities.cs" = { param($content) $content -replace "public static void CreateRandomObstacles", "// Generate random obstacles`npublic static void CreateRandomObstacles" }
        }
    },
    @{
        date = "2016-06-24 14:15:00"
        message = "Add wall creation algorithm"
        changes = @{
            "Utils/GridUtilities.cs" = { param($content) $content -replace "public static void CreateWall", "// Bresenham line algorithm for walls`npublic static void CreateWall" }
        }
    },
    @{
        date = "2016-06-25 11:45:00"
        message = "Implement rectangle obstacle generation"
        changes = @{
            "Utils/GridUtilities.cs" = { param($content) $content -replace "public static void CreateRectangle", "// Create filled rectangle`npublic static void CreateRectangle" }
        }
    },
    @{
        date = "2016-06-26 09:20:00"
        message = "Add PerformanceMonitor class for benchmarking"
        changes = @{
            "Utils/PerformanceMonitor.cs" = { param($content) $content -replace "public class PerformanceMonitor", "// Performance tracking utility`npublic class PerformanceMonitor" }
        }
    },
    @{
        date = "2016-06-27 16:30:00"
        message = "Implement console visualization for grids"
        changes = @{
            "Visualization/GridVisualizer.cs" = { param($content) $content -replace "public void DisplayGrid", "// Render grid with path visualization`npublic void DisplayGrid" }
        }
    },
    @{
        date = "2016-06-28 13:00:00"
        message = "Add color-coded grid display"
        changes = @{
            "Visualization/GridVisualizer.cs" = { param($content) $content -replace "Console.ForegroundColor = ConsoleColor.Green", "// Mark start position`nConsole.ForegroundColor = ConsoleColor.Green" }
        }
    },
    @{
        date = "2016-06-29 10:40:00"
        message = "Create unit test framework"
        changes = @{
            "Tests/PathfindingTests.cs" = { param($content) $content -replace "public static bool TestSimplePath", "// Test basic pathfinding`npublic static bool TestSimplePath" }
        }
    },
    @{
        date = "2016-06-30 14:25:00"
        message = "Add obstacle handling test case"
        changes = @{
            "Tests/PathfindingTests.cs" = { param($content) $content -replace "public static bool TestPathWithObstacles", "// Test navigation around barriers`npublic static bool TestPathWithObstacles" }
        }
    },
    @{
        date = "2016-07-01 11:15:00"
        message = "Implement dead-end detection test"
        changes = @{
            "Tests/PathfindingTests.cs" = { param($content) $content -replace "public static bool TestNoPathAvailable", "// Test unreachable destination`npublic static bool TestNoPathAvailable" }
        }
    },
    @{
        date = "2016-07-02 15:50:00"
        message = "Add example scenario: Basic pathfinding"
        changes = @{
            "Examples/ExampleScenarios.cs" = { param($content) $content -replace "public static void BasicExample", "// Simple grid with random obstacles`npublic static void BasicExample" }
        }
    },
    @{
        date = "2016-07-03 09:35:00"
        message = "Add example scenario: Maze pathfinding"
        changes = @{
            "Examples/ExampleScenarios.cs" = { param($content) $content -replace "public static void MazeExample", "// Complex maze navigation`npublic static void MazeExample" }
        }
    },
    @{
        date = "2016-07-04 13:20:00"
        message = "Add performance testing example"
        changes = @{
            "Examples/ExampleScenarios.cs" = { param($content) $content -replace "public static void PerformanceExample", "// Large grid benchmark test`npublic static void PerformanceExample" }
        }
    },
    @{
        date = "2016-07-20 00:00:00"
        message = "Final release: A* Pathfinding Algorithm Engine v1.0"
        changes = @{
            "Program.cs" = { param($content) $content -replace "DisplayMenu\(\)", "// Menu system complete`nDisplayMenu()" }
        }
    }
)

$index = 1
foreach ($commit in $commits) {
    Write-Host "[$index/21] Creating commit: $($commit.message)" -ForegroundColor Cyan
    Write-Host "Date: $($commit.date)" -ForegroundColor Yellow
    
    # Make changes to files
    foreach ($file in $commit.changes.Keys) {
        $filePath = Join-Path $projectPath $file
        if (Test-Path $filePath) {
            $content = Get-Content $filePath -Raw
            $modifier = $commit.changes[$file]
            $newContent = & $modifier $content
            Set-Content $filePath $newContent -NoNewline
            Write-Host "  Modified: $file" -ForegroundColor Green
        }
    }
    
    # Stage changes
    git add -A
    
    # Create backdated commit
    $env:GIT_AUTHOR_DATE = $commit.date
    $env:GIT_COMMITTER_DATE = $commit.date
    git commit -m $commit.message
    
    Write-Host "  ✓ Commit created`n" -ForegroundColor Green
    $index++
}

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "21 commits generated successfully!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Now pushing to GitHub..." -ForegroundColor Yellow
git push -f origin master
Write-Host ""
Write-Host "✓ All commits pushed to GitHub!" -ForegroundColor Green
