# Decisiones Técnicas - Task Manager

## Contexto
Este documento explica las decisiones técnicas tomadas durante el desarrollo.

## 1. Elección de Blazor Server

**Decisión:** Usar Blazor Server en lugar de Blazor WebAssembly

**Razones:**
- Menor tamaño de descarga inicial
- Ejecución más rápida (lógica en servidor)
- Acceso directo a servicios del servidor
- Ideal para aplicaciones de gestión interna

**Trade-offs:**
- Requiere conexión constante al servidor
- Mayor carga en el servidor

## 2. SQLite como Base de Datos

**Decisión:** SQLite en lugar de SQL Server

**Razones:**
- No requiere instalación de servidor de BD
- Archivo único portátil
- Suficiente para el alcance del proyecto
- Fácil de probar y demostrar

## 3. Arquitectura en Capas

**Decisión:** Separación en Models, Services, Data, Components

**Razones:**
- Separación de responsabilidades
- Facilita testing unitario
- Código más mantenible
- Escalabilidad futura

## 4. Patrón Repository + Service

**Decisión:** Servicios intermedios entre UI y datos

**Razones:**
- Abstracción de la lógica de negocio
- Componentes más limpios
- Reutilización de código
- Facilita cambios en persistencia

## 5. Interfaces para Servicios

**Decisión:** Definir contratos con interfaces

**Razones:**
- Dependency Injection más flexible
- Facilita mocking en tests
- Cumple con SOLID (D - Dependency Inversion)

## 6. BCrypt para Passwords

**Decisión:** BCrypt.Net-Next para hashing

**Razones:**
- Estándar de la industria
- Resistente a ataques de fuerza bruta
- Salting automático
- Adaptive hashing (configurable)

## 7. SessionService como Singleton

**Decisión:** Singleton en lugar de Scoped

**Razones:**
- Mantener sesión entre circuitos de Blazor
- Una única instancia por aplicación
- Simplicidad en gestión de estado

**Nota para producción:** En producción se debería usar cookies o JWT

## 8. Validación Dual

**Decisión:** Validación en frontend y backend

**Razones:**
- UX mejorada (feedback inmediato)
- Seguridad (no confiar solo en cliente)
- Best practice de desarrollo web
