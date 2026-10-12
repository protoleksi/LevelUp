# AGENTS.md - Unity Clicker Project

## Project Overview
Unity 6 (6000.0.6f1) clicker game with coin mechanics, upgrades, and progress bar.

## Scripts
- `Assets/Scripts/ClickerController.cs` - Main game logic
- `Assets/Scripts/CharacterClickHandler.cs` - Click handling on character
- `Assets/Scripts/AutoCoinGenerator.cs` - Auto coin generation per second

## Known Issues & Fixes Applied

### 1. Progress Bar Relative to Background "BAR" ✅ FIXED
- Added `_barBackground` (RectTransform) reference in Inspector
- Progress bar now auto-stretches to match BAR background size in Awake
- Progress clamped at 1.0 (fillAmount max = 1)

### 2. Two Coins Per Second Text Objects ✅ FIXED
- `_coinsPerSecondText` - shows actual current coins/second (under progress bar)
- `_upgradeRewardText` - shows +X for next upgrade (on upgrade button, configurable via Inspector)
- Removed extra text from upgrade cost text

### 3. Coins Exceeding Progress Bar Max ✅ FIXED
- Added `_capCoinsAtMaxValue` toggle in Inspector
- When enabled, coins hard-capped at `_progressBarMaxValue`
- When disabled, coins can exceed max (visual progress bar still clamps at 100%)

### 4. Disable Saving for Testing ✅ FIXED
- Added `_enableAutoSave` toggle in Inspector
- When disabled: no auto-save, no save on pause/quit
- Added `SetAutoSaveEnabled(bool)` method for runtime control

### 5. Inspector Values Overridden by Save Data ✅ FIXED
- Added `_resetOnStart` toggle in Inspector
- When enabled: clears PlayerPrefs on start, uses Inspector default values
- Useful for testing with clean slate

### 6. Number Formatting (K, M, B) ✅ FIXED
- All number displays use `FormatNumber()` for compact display
- 1000+ → 1K, 1M, 1B etc.

### 7. Progress Text on Bar ✅ FIXED
- Added `_progressBarText` for "current / max" display
- Uses same formatting (K/M/B)

## Current Configuration (Inspector-adjustable)
- Coins per click: 10
- Base upgrade cost: 500
- Upgrade cost multiplier: 1.15
- Upgrade coins/sec increase: 1 (shown as +1 on button)
- Progress bar max value: 1500 (visual reference)
- Cap coins at max: false (toggle)
- Enable auto-save: true (toggle)
- Reset on start: false (toggle)
- Auto-save interval: 5 seconds

## Scene Objects (Game.unity)
- `MainContent/Image` - Character (clickable) → add `CharacterClickHandler`
- `param/в секунду` - Coins per second display (under progress bar) → assign to `_coinsPerSecondText`
- `progress` - Progress bar fill image → assign to `_progressBar`
- `BAR` - Background for progress bar → assign to `_barBackground`
- `LevelUp/ButtunLevelUp` - Upgrade button → assign to `_upgradeButton`
- `LevelUp/ButtunLevelUp/500/1,5k` - Upgrade cost text → assign to `_upgradeCostText`
- New text on button for reward → assign to `_upgradeRewardText`
- New text on progress bar → assign to `_progressBarText` (optional)

## Setup Instructions

### Progress Bar Setup
1. `progress` Image: `Image Type = Filled`, `Fill Method = Horizontal`, `Fill Origin = Left`
2. `_barBackground` = drag `BAR` object (parent or sibling RectTransform)
3. In Awake, progress bar rect auto-stretches to match BAR size

### Upgrade Button Text
1. Create child TextMeshProUGUI on `ButtunLevelUp` (or use existing)
2. Set text to "+1" initially
3. Assign to `_upgradeRewardText`
4. Value `_upgradeCoinsPerSecondIncrease` controls the "+X" shown

### Progress Bar Text (Optional)
1. Create child TextMeshProUGUI on `progress` object
2. Position center/over progress bar
3. Assign to `_progressBarText`
4. Shows "current / max" with K/M/B formatting

### Disable Saving for Testing
- Uncheck `_enableAutoSave` in Inspector on ClickerController
- Or check `_resetOnStart` to clear save data on each play
- Or call `clickerController.SetAutoSaveEnabled(false)` from another script