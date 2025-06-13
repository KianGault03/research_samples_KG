# Research Samples – Generative AI Enhanced Static Analysis

This repository contains code samples used in the Honours research project titled **"Generative AI for Enhancing Output from Static Analysis"**. The aim is to show how AI models can enrich the feedback given by traditional static checkers like Roslyn, particularly for novice developers.

## 🧪 Purpose

These samples demonstrate:

- Static errors detectable by Roslyn (e.g., nullability issues, unreachable code).
- How large language models (LLMs) enhance static analysis feedback.
- Examples of concurrency issues **not detected** by Roslyn but identified by LLMs.
- Differences in LLM output based on prompt variation (diagnostics only vs diagnostics + code).

## 🚀 How to Run

```bash
git clone https://github.com/KianGault03/research_samples_KG.git
cd research_samples_KG
open `research_samples_repo.sln` in Visual Studio.
```

## 📝 Sample Usage

Each sample contains:

- **Roslyn Output**: Standard compiler warnings/errors.
- **LLM Output**: AI-enhanced explanations with analogies, based on the Roslyn output.
- **Extended LLM Output**: AI-enhanced explanations with analogies, code references, suggested refactoring, and extended static analysis (targeted at hidden vulnerabilities, such as concurrency/thread issues).

## 🧾 Sample Types

The repository includes a range of sample types designed to evaluate both traditional and enhanced static analysis methods:

- **Self-authored Samples**: Written specifically for this project to simulate beginner-level mistakes and concurrency bugs.
- **Real-world Samples**: Extracted from authentic, open-source codebases and then annotated for use in the study.
- **LLM-generated Samples**: Code produced by large language models (ChatGPT, Claude) to test how different AI-generated coding styles affect static analysis outcomes.

These different types allow for a more diverse assessment of how well AI can augment traditional static checkers.

## 📞 Contact

**Author:** Kian Gault – [kian.gault@outlook.com](mailto:kian.gault@outlook.com)
