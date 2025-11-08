# 🎮 TicTacToe-CSharp

Um simples jogo da velha para o console, desenvolvido em **C#**.  
O programa utiliza o algoritmo **MiniMax** para encontrar a melhor jogada, garantindo partidas desafiadoras contra o computador.

---

## 🚀 Funcionalidades
- Tabuleiro padrão **3x3** usando MiniMax.
- Suporte para tabuleiros maiores (**6x6, 9x9, etc.**), porém terá que ajustar a dificuldade do bot para "Very easy", evitando assim, cálculos intensivos.
- Opção de jogar contra o computador. (Futuramente será possível jogar contra outro player local).
- Código simples e bem estruturado para fins de estudo.

---

## Dicas
- Para alterar a dificuldade, visite 'src/Enums/Difficulty.cs', copie o nome da dificuldade e vá até 'src/Program.cs', então altere a variável 'DIFFICULTY_LEVEL' para a dificuldade desejada.
- Se quiser ajustar as chances para cada nível de dificuldade, vá até 'src\Players\AIPlayer.cs', dentro do construtor as chances são inicializadas, quanto maior a chance, mais fácil será.

---

## 📦 Como executar
1. Clone este repositório:
   ```bash
   git clone https://github.com/Elemental432/TicTacToe-CSharp.git
