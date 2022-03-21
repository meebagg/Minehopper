# Minehopper
Minesweeper test project

Some notes
==========
- Dependency injection is handled by Splat with some RxUI extensions.  
- Default settings (grid width, height, mine count and lives) live in DefaultConfig.  
- GameService starts everything after being resolved in Main.  
- Minefield grid creation lives in GridCreationService.  
- Navigation functionality lives in GridNavigationService.  
- GridService attempts to abstract some of the creation and navigation away from GameService.  
- NUnit tests are named "Member being tested"-"Testdata"-"Expected result" or similar.  

With more time, I would:
========================
- Ensure game is always 'winnable' (i.e. player can't be surrounded by mines).  
- Add tests around traversal across the grid.  
