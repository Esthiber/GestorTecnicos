-- Tecnicos
INSERT INTO [dbo].[Tecnicos] (Nombres, SueldoHora) VALUES
('Juan Pérez', 15.50),
('María Gómez', 18.75),
('Carlos Rodríguez', 20.00),
('Ana Martínez', 16.80),
('Pedro Sánchez', 19.20),
('Luis Ramírez', 17.50),
('Laura Fernández', 21.30),
('Jorge Herrera', 14.90),
('Carmen Torres', 22.40),
('Miguel López', 16.00),
('Sofía Díaz', 19.50),
('Roberto Vargas', 18.25),
('Elena Castillo', 17.80),
('Andrés Navarro', 20.50),
('Isabel Ríos', 21.10),
('Fernando Molina', 15.60),
('Patricia Ortega', 23.00),
('Ricardo Jiménez', 19.90),
('Gabriela Silva', 16.40),
('Héctor Mendoza', 22.00);

-- Ciudades de Ejemplo
INSERT INTO [dbo].[Ciudades] (Nombre) VALUES
('Santo Domingo'),
('Santiago'),
('La Vega'),
('San Cristóbal'),
('Puerto Plata'),
('San Pedro de Macorís'),
('Higüey'),
('Bonao'),
('Moca'),
('Azua'),
('La Romana'),
('San Francisco de Macorís'),
('Barahona'),
('Bani'),
('Monte Cristi'),
('Nagua'),
('San Juan de la Maguana'),
('Cotuí'),
('Dajabón'),
('Hato Mayor');

-- Clientes
INSERT INTO [dbo].[Clientes] (FechaIngreso, Nombres, Direccion, Rnc, LimiteCredito, TecnicoId, CiudadId) VALUES
('2024-01-01', 'Carlos Medina', 'Av. Independencia #123', '101234567', 5000.00, 1, 2),
('2024-02-05', 'María Rodríguez', 'Calle Duarte #456', '102345678', 7500.00, 2, 3),
('2024-03-10', 'Luis Pérez', 'Calle Sánchez #789', '103456789', 6200.00, 3, 4),
('2024-04-15', 'Ana González', 'Av. Bolívar #101', '104567890', 9000.00, 4, 5),
('2024-05-20', 'Pedro Fernández', 'Calle Mella #202', '105678901', 4500.00, 5, 6),
('2024-06-25', 'Laura Ramírez', 'Av. Churchill #303', '106789012', 8200.00, 6, 7),
('2024-07-30', 'Jorge Herrera', 'Calle El Conde #404', '107890123', 6800.00, 7, 8),
('2024-08-05', 'Carmen Torres', 'Av. Lincoln #505', '108901234', 7200.00, 8, 9),
('2024-09-10', 'Miguel López', 'Calle Mercedes #606', '109012345', 5500.00, 9, 10),
('2024-10-15', 'Sofía Díaz', 'Av. 27 de Febrero #707', '110123456', 7900.00, 10, 11);

-- Tickets
INSERT INTO [dbo].[Tickets] (Fecha, Prioridad, ClienteId, TecnicoId, Asunto, Descripcion, TiempoInvertido) VALUES
('2024-01-05', 1, 1, 1, 'Falla en el sistema', 'El sistema no responde al iniciar sesión', 45),
('2024-01-10', 2, 2, 2, 'Problema con impresora', 'La impresora no imprime documentos en red', 30),
('2024-01-15', 3, 3, 3, 'Error en base de datos', 'Se presentan errores de integridad en la BD', 60),
('2024-01-20', 1, 4, 4, 'Fallo de red', 'Pérdida de conexión en varios equipos', 90),
('2024-01-25', 2, 5, 5, 'Correo no funciona', 'Los correos no se están enviando ni recibiendo', 40),
('2024-02-01', 3, 6, 6, 'Actualización de software', 'Requiere actualización de sistema operativo', 120),
('2024-02-05', 1, 7, 7, 'Problema con acceso', 'Usuario no puede acceder a la plataforma', 35),
('2024-02-10', 2, 8, 8, 'Falla en servidor', 'El servidor presenta reinicios inesperados', 95),
('2024-02-15', 3, 9, 9, 'Solicitud de instalación', 'Instalación de nuevos programas en PCs', 80),
('2024-02-20', 1, 10, 10, 'Pantalla azul', 'La PC muestra pantalla azul al iniciar', 50);

INSERT INTO Sistemas (Descripcion, Complejidad) VALUES
('Sistema de Inventario', 45.5),
('Sistema de Facturación', 30.2),
('Gestión de Clientes', 70.8),
('Plataforma de Recursos Humanos', 25.6),
('Sistema de Monitoreo', 80.3),
('Software de Contabilidad', 55.4),
('Aplicación de Control de Acceso', 40.1),
('Plataforma de E-commerce', 95.7),
('Sistema de Logística', 65.3),
('Gestión de Documentos', 20.5),
('Software de Punto de Venta', 50.0),
('Sistema de Reservas', 33.8),
('Plataforma de e-Learning', 75.9),
('Gestión de Tickets', 22.4),
('Sistema de Reportes', 15.7),
('Software de Monitoreo de Servidores', 88.2),
('Plataforma de Streaming', 99.9),
('Sistema de Alertas', 10.3),
('Aplicación de Encuestas', 18.9),
('Gestión de Activos', 28.7);

