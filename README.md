# 🐍 Snake Game

A classic Snake game implementation built with C# and Windows Forms, featuring clean architecture and smooth gameplay.

## 📖 Overview

This is a modern implementation of the classic Snake game where the player controls a snake to eat food and grow longer while avoiding collisions with walls and the snake's own body.

## ✨ Features

- **Classic Snake Gameplay**: Navigate the snake to eat food and grow longer
- **Smart Controls**: Arrow keys with direction validation (prevents 180° turns)
- **Collision Detection**: Wall and self-collision detection
- **Win/Lose Conditions**: Complete the board or hit an obstacle
- **Restart Functionality**: Press F5 to start a new game
- **Square Cell Rendering**: Automatic form adjustment for perfect square cells
- **Smooth Animation**: Configurable refresh rate for optimal gameplay
- **Visual Grid**: Clear game board with customizable colors

## 🎮 How to Play

### Controls
- **↑ Arrow Key**: Move up
- **↓ Arrow Key**: Move down
- **← Arrow Key**: Move left  
- **→ Arrow Key**: Move right
- **F5**: Restart the game

### Rules
1. Control the snake using arrow keys
2. Eat the red food to grow longer
3. Avoid hitting walls or your own body
4. Fill the entire board to win!

### Strategy Tips
- Plan your path to avoid trapping yourself
- The snake cannot reverse direction (move directly backwards)
- Food appears randomly in empty cells

## 🛠️ Technical Details

### Architecture

The project follows a clean, modular architecture with clear separation of concerns:

```
Snake/
├── Model/                  # Game logic and data models
│   ├── Game.cs            # Main game controller
│   ├── Snake.cs           # Snake entity and movement
│   ├── Board.cs           # Game board representation
│   ├── Position.cs        # Position record
│   ├── Direction.cs       # Movement directions
│   ├── CellType.cs        # Board cell types
│   ├── StepResult.cs      # Game state results
│   └── Constants.cs       # Game configuration
├── Representation/         # Visual rendering
│   └── GameDrawer.cs      # Graphics and drawing logic
├── Utilities/             # Helper classes
│   └── FormSizeAdjuster.cs # Form size optimization
└── Form1.cs              # Main UI form
```

### Key Components

#### Game Engine (`Game.cs`)
- Manages game state and logic
- Handles input validation and snake movement
- Implements collision detection
- Manages food generation and scoring

#### Snake Entity (`Snake.cs`)
- Represents the snake with position tracking
- Handles movement and growth mechanics
- Provides body segment access for rendering
- Implements eating behavior with events

#### Visual Renderer (`GameDrawer.cs`)
- Handles all graphics rendering
- Draws snake, food, and game grid
- Calculates cell dimensions dynamically
- Uses efficient painting with proper resource disposal

#### Smart Controls
- Direction validation prevents impossible moves
- F5 restart functionality

### Technologies Used

- **Framework**: .NET 8.0 Windows Forms
- **Language**: C# 12 with nullable reference types enabled
- **Graphics**: GDI+ for custom rendering

### Configuration

Game settings can be customized in `Constants.cs`:

```csharp
public static int BoardWidth = 50;      // Board width in cells
public static int BoardHeight = 50;     // Board height in cells
public static TimeSpan RefreshRate = TimeSpan.FromSeconds(0.1); // Game speed

// Visual customization
public static Color Background = Color.Lime;
public static Color Snake = Color.Black;
public static Color Grid = Color.Gray;
public static Color Food = Color.Red;
```

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 or later
- Windows OS (Windows Forms requirement)
- Visual Studio 2022 or compatible IDE

### Running the Game

1. **Clone or download** the project
2. **Open** `Snake.sln` in Visual Studio
3. **Build** the solution (Ctrl+Shift+B)
4. **Run** the application (F5)

### Building from Command Line

```bash
cd Snake
dotnet build
dotnet run
```

## 🎯 Game Features in Detail

### Intelligent Movement System
- The snake cannot move directly backwards (prevents instant death)
- Smooth directional changes with input validation
- Movement is grid-based for precise control

### Dynamic Food System
- Food spawns randomly in empty cells
- Never spawns on the snake's body
- Triggers growth when consumed
- Automatically generates new food after eating

### Win/Lose Conditions
- **Win**: Fill the entire board (snake length = board size - 1)
- **Lose**: Hit walls or snake's own body
- **Restart**: F5 key provides instant game reset

### Visual Polish
- Automatic form resizing for square cells
- Clean, customizable color scheme
- Grid overlay for clear cell boundaries
- Efficient rendering with proper graphics disposal

## 🔧 Customization

The game is highly customizable through the `Constants.cs` file:

- **Board Size**: Adjust `BoardWidth` and `BoardHeight`
- **Game Speed**: Modify `RefreshRate` 
- **Colors**: Change `Background`, `Snake`, `Grid`, and `Food` colors
- **Visual Style**: Adjust `GridLineWidth` and other visual properties

## 🐛 Known Issues

- None currently reported

## 🤝 Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.

## 📄 License

This project is open source and available under the MIT License.

## 🎮 Screenshots

*Game in action showing the snake, food, and grid system*

---

**Enjoy the game!** 🐍✨
