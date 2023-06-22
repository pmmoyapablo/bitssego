-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 19-11-2020 a las 19:01:54
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `vesisgestiontfhka`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_accessories`
--

CREATE TABLE `sisg_accessories` (
  `id` int(11) NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(150) DEFAULT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_accessories`
--

INSERT INTO `sisg_accessories` (`id`, `name`, `description`, `creation_date`) VALUES
(1, 'Manual de Usuario', NULL, '2019-10-23 15:57:40'),
(2, 'Cable de alimentación', '3 metro', '2019-10-23 15:58:05'),
(3, 'Cable de prueba', '3 metro', '2019-10-23 17:31:25'),
(4, 'Scanner Lector', 'EAN13', '2019-10-23 15:57:40'),
(5, 'Display Aclas', '4 lineas', '2019-10-23 15:58:05'),
(6, 'Gaveta de Dinero', 'Aclas con cerradura electrica', '2019-10-25 15:21:54'),
(7, 'Hand Help', 'Dispositivo de lectura y extracción de datos', '2019-10-25 15:23:05');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_accessoriesorders`
--

CREATE TABLE `sisg_accessoriesorders` (
  `id` int(11) NOT NULL,
  `orderId` int(11) NOT NULL,
  `accesoryId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_accessoriesorders`
--

INSERT INTO `sisg_accessoriesorders` (`id`, `orderId`, `accesoryId`) VALUES
(1, 1, 1),
(2, 1, 3),
(3, 5, 2),
(4, 5, 3),
(7, 6, 4),
(8, 7, 2),
(9, 7, 3),
(10, 8, 2),
(11, 8, 4),
(12, 8, 5),
(13, 8, 6),
(14, 9, 1),
(16, 18, 3),
(17, 18, 4),
(18, 19, 3),
(19, 19, 4),
(20, 20, 2),
(21, 20, 3),
(22, 21, 2),
(23, 22, 1),
(24, 23, 4),
(25, 23, 5),
(26, 24, 1),
(27, 25, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_accessroles`
--

CREATE TABLE `sisg_accessroles` (
  `id` int(20) NOT NULL,
  `level` int(2) NOT NULL,
  `description` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `sisg_accessroles`
--

INSERT INTO `sisg_accessroles` (`id`, `level`, `description`, `creation_date`) VALUES
(1, 10, 'Super Usuario', '2019-04-08 12:04:09'),
(2, 9, 'Avanzado', '2019-04-08 12:04:21'),
(3, 8, 'Intermedio 3', '2019-04-08 12:04:21'),
(4, 7, 'Intermedio 2', '2019-04-08 12:04:21'),
(5, 6, 'Intermedio 1', '2019-04-08 12:04:21'),
(6, 5, 'Básico 3', '2019-04-08 12:04:21'),
(7, 4, 'Básico 2', '2019-04-08 12:04:21'),
(8, 3, 'Básico 1', '2019-04-08 12:04:21'),
(9, 2, 'Invitado', '2019-04-08 12:04:21'),
(10, 1, 'Sin Privilegios', '2019-04-08 12:04:21');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_activities`
--

CREATE TABLE `sisg_activities` (
  `id` int(11) NOT NULL,
  `employeeId` int(11) NOT NULL,
  `process` varchar(150) NOT NULL,
  `operation` varchar(150) NOT NULL,
  `serial` varchar(13) NOT NULL,
  `detail` varchar(150) NOT NULL,
  `operationDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_activities`
--

INSERT INTO `sisg_activities` (`id`, `employeeId`, `process`, `operation`, `serial`, `detail`, `operationDate`) VALUES
(1, 1, 'Seriales de Productos', 'Eliminación', 'Z1B3332211', 'Se efectuo el cambio porque se importo un serial incorrecto', '2020-06-04 13:40:00'),
(2, 2, 'Seriales de Repuestos', 'Carga Manual', 'F0112345ABD', 'Se cargo para TEST', '2020-06-01 00:00:00'),
(3, 1, 'Enajenaciones', 'Borrado', 'Z1B8051656', 'Tramitado interno', '2020-06-17 18:41:02'),
(4, 1, 'Seriales de Productos', 'Carga Manual', 'DLA7008899', 'Para uso interno', '2020-06-17 19:15:44'),
(5, 1, 'Seriales de Productos', 'Carga Manual', 'Z1B0000000', 'Para uso interno', '2020-06-19 12:05:20'),
(6, 1, 'Seriales de Productos', 'Carga Manual', 'Z1F0000000', 'Para Distribudor partcular por Nota de Entrega', '2020-06-19 12:06:57'),
(7, 1, 'Seriales de Repuestos', 'Carga Manual', 'F01EDF43231', 'Para uso interno', '2020-06-19 12:32:35'),
(8, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F4343320', 'Para Distribudor partcular por Nota de Entrega', '2020-06-19 12:33:48'),
(9, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B9098760', 'Para Distribudor partcular por Nota de Entrega', '2020-06-19 12:33:49'),
(10, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1A3321210', 'Para Distribudor partcular por Nota de Entrega', '2020-06-19 12:33:50'),
(11, 1, 'Seriales de Productos', 'Carga Manual', 'DLA5555555', 'Para uso interno', '2020-06-19 13:20:37'),
(12, 1, 'Enajenaciones', 'Borrado', 'ZPA3333333', 'Tramitado interno', '2020-06-19 13:57:29'),
(13, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F4341327', 'Para Distribudor partcular por Nota de Entrega', '2020-06-22 14:19:01'),
(14, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B9078767', 'Para Distribudor partcular por Nota de Entrega', '2020-06-22 14:19:01'),
(15, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1A3321213', 'Para Distribudor partcular por Nota de Entrega', '2020-06-22 14:19:02'),
(16, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F4341328', 'Para Distribudor partcular por Nota de Entrega', '2020-06-22 14:29:13'),
(17, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B9078769', 'Para Distribudor partcular por Nota de Entrega', '2020-06-22 14:29:14'),
(18, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1A3321214', 'Para Distribudor partcular por Nota de Entrega', '2020-06-22 14:29:15'),
(19, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F4341329', 'Para Distribudor partcular por Nota de Entrega', '2020-06-22 14:33:56'),
(20, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B9078719', 'Para Distribudor partcular por Nota de Entrega', '2020-06-22 14:33:57'),
(21, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1A3321244', 'Para Distribudor partcular por Nota de Entrega', '2020-06-22 14:33:59'),
(22, 1, 'Seriales de Productos', 'Carga Manual', 'DLA2211222', 'Para uso interno', '2020-06-23 08:55:44'),
(23, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F4341349', 'Para Distribudor partcular por Nota de Entrega', '2020-06-23 08:56:09'),
(24, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B9078949', 'Para Distribudor partcular por Nota de Entrega', '2020-06-23 08:56:10'),
(25, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1A3321204', 'Para Distribudor partcular por Nota de Entrega', '2020-06-23 08:56:11'),
(26, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B8887766', 'Para Distribudor partcular por Nota de Entrega', '2020-06-25 14:12:25'),
(27, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA1235555', 'Para Distribudor partcular por Nota de Entrega', '2020-06-25 14:12:28'),
(28, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B8887767', 'Para Distribudor partcular por Nota de Entrega', '2020-06-25 14:22:21'),
(29, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA1235558', 'Para Distribudor partcular por Nota de Entrega', '2020-06-25 14:22:21'),
(30, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B8887768', 'Para Distribudor partcular por Nota de Entrega', '2020-06-25 14:26:19'),
(31, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA1235559', 'Para Distribudor partcular por Nota de Entrega', '2020-06-25 14:26:20'),
(32, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F01B8887768', 'Para Distribudor partcular por Nota de Entrega', '2020-06-25 14:28:44'),
(33, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F02A1235559', 'Para Distribudor partcular por Nota de Entrega', '2020-06-25 14:28:44'),
(34, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453322', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 15:30:59'),
(35, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564533', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 15:31:00'),
(36, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453323', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 15:47:05'),
(37, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564534', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 15:47:05'),
(38, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453324', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 15:53:22'),
(39, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564535', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 15:53:22'),
(40, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453325', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:00:27'),
(41, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564536', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:00:28'),
(42, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453327', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:03:57'),
(43, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564538', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:03:58'),
(44, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453328', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:19:53'),
(45, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564539', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:19:54'),
(46, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453329', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:28:48'),
(47, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564540', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:28:49'),
(48, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453330', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:32:51'),
(49, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564541', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:32:52'),
(50, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453331', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:40:56'),
(51, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564542', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:40:57'),
(52, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5453332', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:51:01'),
(53, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F6564543', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:51:02'),
(54, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F01DA545333', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:56:07'),
(55, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F0265C4543A', 'Para Distribudor partcular por Nota de Entrega', '2020-06-30 16:56:07'),
(56, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B9890044', 'Para Distribudor partcular por Nota de Entrega', '2020-07-01 13:56:58'),
(57, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA7234449', 'Para Distribudor partcular por Nota de Entrega', '2020-07-01 13:57:00'),
(58, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F019890A044', 'Para Distribudor partcular por Nota de Entrega', '2020-07-01 14:56:40'),
(59, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F027234449C', 'Para Distribudor partcular por Nota de Entrega', '2020-07-01 14:56:41'),
(60, 1, 'Seriales de Productos', 'Carga Manual', 'Z1F4323233', 'Para uso interno', '2020-07-15 12:41:22'),
(61, 1, 'Seriales de Productos', 'Carga Manual', 'DLA7453212', 'Para uso interno', '2020-07-15 12:53:59'),
(62, 1, 'Seriales de Productos', 'Carga Manual', 'Z1B3333333', 'Para uso interno', '2020-07-22 09:05:10'),
(63, 1, 'Seriales de Productos', 'Carga Manual', 'Z1B8777777', 'Para Distribudor partcular por Nota de Entrega', '2020-07-22 09:06:55'),
(64, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1B8927218', 'Para Distribudor partcular por Nota de Entrega', '2020-07-22 09:09:15'),
(65, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'Z1F5454376', 'Para Distribudor partcular por Nota de Entrega', '2020-07-22 09:09:16'),
(66, 1, 'Seriales de Productos', 'Carga Manual por Lote', 'DLA5454312', 'Para Distribudor partcular por Nota de Entrega', '2020-07-22 09:09:17'),
(67, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F01D567EA2C', 'Para Distribudor partcular por Nota de Entrega', '2020-07-22 09:20:12'),
(68, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F011237EA20', 'Para Distribudor partcular por Nota de Entrega', '2020-07-22 09:20:12'),
(69, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F01A567EBB0', 'Para Distribudor partcular por Nota de Entrega', '2020-07-22 09:20:13'),
(70, 1, 'Seriales de Repuestos', 'Carga Manual por Lote', 'F02D5C75A45', 'Para Distribudor partcular por Nota de Entrega', '2020-07-22 09:20:13'),
(71, 1, 'Seriales de Productos', 'Carga Manual', 'DLA4354545', 'Para uso interno', '2020-10-08 14:11:51');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_alienations`
--

CREATE TABLE `sisg_alienations` (
  `id` int(11) NOT NULL,
  `serial` varchar(13) NOT NULL,
  `providerId` int(11) NOT NULL,
  `distributorId` int(11) NOT NULL,
  `finalclientId` int(11) NOT NULL,
  `status` varchar(20) NOT NULL,
  `observations` varchar(350) DEFAULT NULL,
  `alienationDate` datetime NOT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_alienations`
--

INSERT INTO `sisg_alienations` (`id`, `serial`, `providerId`, `distributorId`, `finalclientId`, `status`, `observations`, `alienationDate`, `creation_date`) VALUES
(1, 'Z1B8100007', 1, 7, 38, 'PROCESADO', 'Producto Bits Americas SAS', '2020-03-27 13:44:24', '2020-04-03 16:34:17'),
(4, 'Z1B1234567', 1, 7, 8, 'PROCESADO', 'Enajenación Automática por Fiscalización', '2020-04-01 14:56:00', '2020-04-01 14:56:29'),
(6, 'Z1B8051656', 1, 18, 44, 'PROCESADO', '1 Impresora SRP-350', '2020-04-08 16:38:36', '2020-04-08 16:39:59'),
(7, 'DLA7005357', 2, 19, 52, 'DECLARADO', 'Enajenación Manual', '2020-04-08 17:18:19', '2020-04-30 12:17:33'),
(8, 'Z1B8051657', 1, 18, 1, 'PROCESADO', 'Enajenación Manual', '2020-04-08 18:56:11', '2020-04-08 18:56:23'),
(9, 'Z1B8532223', 1, 2, 1758, 'PROCESADO', 'Enajenación Automatica por Fiscalizacion', '2020-04-14 00:21:56', '2020-04-14 00:23:32'),
(10, 'DLA7000001', 2, 2, 1761, 'DECLARADO', 'Enajenación Automatica', '2020-04-17 13:05:18', '2020-04-30 12:17:38'),
(11, 'ZPA3333333', 1, 2, 1757, 'PROCESADO', 'Enajenación Manual', '2020-05-07 16:32:57', '2020-05-07 16:33:31'),
(12, 'ZPA0001122', 1, 2, 44, 'PROCESADO', 'Enajenación Manual', '2020-05-11 12:17:33', '2020-05-11 12:18:25'),
(13, 'DLA7234449', 2, 2, 44, 'PROCESADO', 'Enajenación Manual', '2020-07-16 19:06:29', '2020-07-16 19:06:37'),
(14, 'Z1A3321212', 1, 2, 1, 'PROCESADO', 'Manual', '2020-09-22 10:23:32', '2020-09-22 10:23:42');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_categories`
--

CREATE TABLE `sisg_categories` (
  `id` int(11) NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(150) DEFAULT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_categories`
--

INSERT INTO `sisg_categories` (`id`, `name`, `description`, `creation_date`) VALUES
(1, 'Impresoras Fiscales', 'Dispositivo que permite registrar y controlar la información que se imprime en un comprobante fiscal (factura)', '2019-10-16 16:41:22'),
(2, 'Impresoras Fiscales para Apuestas', NULL, '2019-10-03 09:53:41'),
(3, 'Cajas Registradoras', NULL, '2019-10-03 09:53:41'),
(4, 'Perifericos y otros', NULL, '2019-10-03 09:53:41'),
(5, 'Plantas Electricas', NULL, '2019-10-03 09:53:41'),
(6, 'Dispositivo de Transmision', NULL, '2019-10-03 09:53:41'),
(11, 'prueba 202020', NULL, '2019-10-07 10:54:47'),
(12, 'Factura Electrónica', NULL, '2019-10-10 14:24:38'),
(13, 'Consumibles', 'Para impresoras standar y papeleria', '2020-02-27 10:40:23');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_chargues`
--

CREATE TABLE `sisg_chargues` (
  `id` int(11) NOT NULL,
  `description` varchar(150) NOT NULL,
  `rolId` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_chargues`
--

INSERT INTO `sisg_chargues` (`id`, `description`, `rolId`) VALUES
(1, 'Gerente de Servicios', 2),
(2, 'Coordinador HelpDesk', 3),
(3, 'Gerente de Soporte y Tecnología', 4),
(4, 'Coordinador de Integración', 3),
(5, 'Coordinador de Soporte Fiscal', 3),
(6, 'Especialista de Integración', 5),
(7, 'Analista de Soporte I', 5),
(8, 'Lider de Prooyecto', 3),
(9, 'Gerente Facturación y Cobranza', 7),
(10, 'Analista de Facturación y Cobranza', 6),
(11, 'Jefe de Taller de Equipos', 3),
(12, 'Técnico de Taller de Equipos', 8),
(13, 'Analista HelpDesk', 5),
(14, 'Coordinador de Laboratorio', 3),
(15, 'Analista de Pruebas', 5),
(16, 'Receptor de Equipos', 6),
(17, 'Analista Administativo', 6),
(18, 'Gerente de Ventas', 7),
(19, 'Ejecutivo de Ventas', 6),
(20, 'Gerente General Administrativo', 7),
(21, 'Gerente de Despacho', 7),
(22, 'Operador de Despacho', 6),
(23, 'Gerente Producción', 7),
(24, 'Operador de Producción', 6),
(25, 'Gerente de Operaciones', 7),
(26, 'Asistente de Operaciones', 6),
(27, 'Gerente de Desarrollo Software', 4),
(28, 'Desarrollador de Software', 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_countries`
--

CREATE TABLE `sisg_countries` (
  `id` int(11) NOT NULL,
  `description` varchar(60) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_countries`
--

INSERT INTO `sisg_countries` (`id`, `description`) VALUES
(1, 'Afganistán'),
(2, 'Islas Gland'),
(3, 'Albania'),
(4, 'Alemania'),
(5, 'Andorra'),
(6, 'Angola'),
(7, 'Anguilla'),
(8, 'AntÃ¡rtida'),
(9, 'Antigua y Barbuda'),
(10, 'Antillas Holandesas'),
(11, 'Arabia SaudÃ­'),
(12, 'Argelia'),
(13, 'Argentina'),
(14, 'Armenia'),
(15, 'Aruba'),
(16, 'Australia'),
(17, 'Austria'),
(18, 'AzerbaiyÃ¡n'),
(19, 'Bahamas'),
(20, 'Bahréin'),
(21, 'Bangladesh'),
(22, 'Barbados'),
(23, 'Bielorrusia'),
(24, 'BÃ©lgica'),
(25, 'Belice'),
(26, 'Benin'),
(27, 'Bermudas'),
(28, 'Bhután'),
(29, 'Bolivia'),
(30, 'Bosnia y Herzegovina'),
(31, 'Botsuana'),
(32, 'Isla Bouvet'),
(33, 'Brasil'),
(34, 'Brunéi'),
(35, 'Bulgaria'),
(36, 'Burkina Faso'),
(37, 'Burundi'),
(38, 'Cabo Verde'),
(39, 'Islas Caimán'),
(40, 'Camboya'),
(41, 'CamerÃºn'),
(42, 'CanadÃ¡'),
(43, 'República Centroafricana'),
(44, 'Chad'),
(45, 'República Checa'),
(46, 'Chile'),
(47, 'China'),
(48, 'Chipre'),
(49, 'Isla de Navidad'),
(50, 'Ciudad del Vaticano'),
(51, 'Islas Cocos'),
(52, 'Colombia'),
(53, 'Comoras'),
(54, 'República Democrática del Congo'),
(55, 'Congo'),
(56, 'Islas Cook'),
(57, 'Corea del Norte'),
(58, 'Corea del Sur'),
(59, 'Costa de Marfil'),
(60, 'Costa Rica'),
(61, 'Croacia'),
(62, 'Cuba'),
(63, 'Dinamarca'),
(64, 'Dominica'),
(65, 'República Dominicana'),
(66, 'Ecuador'),
(67, 'Egipto'),
(68, 'El Salvador'),
(69, 'Emiratos Ãrabes Unidos'),
(70, 'Eritrea'),
(71, 'Eslovaquia'),
(72, 'Eslovenia'),
(73, 'España'),
(74, 'Islas ultramarinas de Estados Unidos'),
(75, 'Estados Unidos'),
(76, 'Estonia'),
(77, 'Etiopía'),
(78, 'Islas Feroe'),
(79, 'Filipinas'),
(80, 'Finlandia'),
(81, 'Fiyi'),
(82, 'Francia'),
(83, 'Gabón'),
(84, 'Gambia'),
(85, 'Georgia'),
(86, 'Islas Georgias del Sur y Sandwich del Sur'),
(87, 'Ghana'),
(88, 'Gibraltar'),
(89, 'Granada'),
(90, 'Grecia'),
(91, 'Groenlandia'),
(92, 'Guadalupe'),
(93, 'Guam'),
(94, 'Guatemala'),
(95, 'Guayana Francesa'),
(96, 'Guinea'),
(97, 'Guinea Ecuatorial'),
(98, 'Guinea-Bissau'),
(99, 'Guyana'),
(100, 'Haití'),
(101, 'Islas Heard y McDonald'),
(102, 'Honduras'),
(103, 'Hong Kong'),
(104, 'Hungría'),
(105, 'India'),
(106, 'Indonesia'),
(107, 'Irán'),
(108, 'Iraq'),
(109, 'Irlanda'),
(110, 'Islandia'),
(111, 'Israel'),
(112, 'Italia'),
(113, 'Jamaica'),
(114, 'Japón'),
(115, 'Jordania'),
(116, 'Kazajstán'),
(117, 'Kenia'),
(118, 'Kirguistán'),
(119, 'Kiribati'),
(120, 'Kuwait'),
(121, 'Laos'),
(122, 'Lesotho'),
(123, 'Letonia'),
(124, 'Líbano'),
(125, 'Liberia'),
(126, 'Libia'),
(127, 'Liechtenstein'),
(128, 'Lituania'),
(129, 'Luxemburgo'),
(130, 'Macao'),
(131, 'ARY Macedonia'),
(132, 'Madagascar'),
(133, 'Malasia'),
(134, 'Malawi'),
(135, 'Maldivas'),
(136, 'Malí'),
(137, 'Malta'),
(138, 'Islas Malvinas'),
(139, 'Islas Marianas del Norte'),
(140, 'Marruecos'),
(141, 'Islas Marshall'),
(142, 'Martinica'),
(143, 'Mauricio'),
(144, 'Mauritania'),
(145, 'Mayotte'),
(146, 'México'),
(147, 'Micronesia'),
(148, 'Moldavia'),
(149, 'Mónaco'),
(150, 'Mongolia'),
(151, 'Montserrat'),
(152, 'Mozambique'),
(153, 'Myanmar'),
(154, 'Namibia'),
(155, 'Nauru'),
(156, 'Nepal'),
(157, 'Nicaragua'),
(158, 'Níger'),
(159, 'Nigeria'),
(160, 'Niue'),
(161, 'Isla Norfolk'),
(162, 'Noruega'),
(163, 'Nueva Caledonia'),
(164, 'Nueva Zelanda'),
(165, 'Omán'),
(166, 'Países Bajos'),
(167, 'Pakistán'),
(168, 'Palau'),
(169, 'Palestina'),
(170, 'Panamá'),
(171, 'Papúa Nueva Guinea'),
(172, 'Paraguay'),
(173, 'Perú'),
(174, 'Islas Pitcairn'),
(175, 'Polinesia Francesa'),
(176, 'Polonia'),
(177, 'Portugal'),
(178, 'Puerto Rico'),
(179, 'Qatar'),
(180, 'Reino Unido'),
(181, 'Reunión'),
(182, 'Ruanda'),
(183, 'Rumania'),
(184, 'Rusia'),
(185, 'Sahara Occidental'),
(186, 'Islas Salomón'),
(187, 'Samoa'),
(188, 'Samoa Americana'),
(189, 'San Cristóbal y Nevis'),
(190, 'San Marino'),
(191, 'San Pedro y Miquelón'),
(192, 'San Vicente y las Granadinas'),
(193, 'Santa Helena'),
(194, 'Santa Lucía'),
(195, 'Santo Tomé y Príncipe'),
(196, 'Senegal'),
(197, 'Serbia y Montenegro'),
(198, 'Seychelles'),
(199, 'Sierra Leona'),
(200, 'Singapur'),
(201, 'Siria'),
(202, 'Somalia'),
(203, 'Sri Lanka'),
(204, 'Suazilandia'),
(205, 'SudÃ¡frica'),
(206, 'Sudán'),
(207, 'Suecia'),
(208, 'Suiza'),
(209, 'Surinam'),
(210, 'Svalbard y Jan Mayen'),
(211, 'Tailandia'),
(212, 'Taiwán'),
(213, 'Tanzania'),
(214, 'Tayikistán'),
(215, 'Territorio Británico del Océano Índico'),
(216, 'Territorios Australes Franceses'),
(217, 'Timor Oriental'),
(218, 'Togo'),
(219, 'Tokelau'),
(220, 'Tonga'),
(221, 'Trinidad y Tobago'),
(222, 'Túnez'),
(223, 'Islas Turcas y Caicos'),
(224, 'Turkmenistán'),
(225, 'Turquía'),
(226, 'Tuvalu'),
(227, 'Ucrania'),
(228, 'Uganda'),
(229, 'Uruguay'),
(230, 'UzbekistÃ¡n'),
(231, 'Vanuatu'),
(232, 'Venezuela'),
(233, 'Vietnam'),
(234, 'Islas Vírgenes Británicas'),
(235, 'Islas Vírgenes de los Estados Unidos'),
(236, 'Wallis y Futuna'),
(237, 'Yemen'),
(238, 'Yibuti'),
(239, 'Zambia'),
(240, 'Zimbabue');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_deliveryorder`
--

CREATE TABLE `sisg_deliveryorder` (
  `id` int(11) NOT NULL,
  `deliveryMode` tinyint(1) NOT NULL,
  `liableId` int(15) DEFAULT NULL,
  `liableName` varchar(40) DEFAULT NULL,
  `liablePhone` varchar(100) DEFAULT NULL,
  `guideNumber` varchar(25) DEFAULT NULL,
  `companyName` varchar(50) DEFAULT NULL,
  `address` varchar(150) DEFAULT NULL,
  `observation` varchar(150) DEFAULT NULL,
  `dispatchDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_deliveryorder`
--

INSERT INTO `sisg_deliveryorder` (`id`, `deliveryMode`, `liableId`, `liableName`, `liablePhone`, `guideNumber`, `companyName`, `address`, `observation`, `dispatchDate`) VALUES
(0, 0, 0, 'No Definido', '00000000', '0000', 'NONE', NULL, NULL, '2020-09-30 00:00:00'),
(1, 1, 1232, 'Pablo', '1232323', '34353', 'ZOOM', 'Calle Luna 34', NULL, '2020-08-29 00:00:00'),
(2, 0, 0, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-01 16:18:57'),
(8, 0, 344246, 'Maria Velota', '04148491448', '990099', 'Fedex', 'Callejon Gutierrez', 'NA', '2020-09-01 17:39:30'),
(9, 1, 3234445, 'Tatiana Rojas', '4343434', '2323', 'MRW', 'Calle 45 con Av Jimenez', 'Ninguna', '2020-09-02 14:36:14'),
(10, 1, 12321323, 'Maria Velota', '04148491448', NULL, NULL, NULL, NULL, '2020-09-08 17:07:04'),
(11, 1, 34424655, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-15 13:32:21'),
(12, 1, 3355667, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-15 13:38:15'),
(13, 1, 12321322, 'Maria Velota', '04148491448', NULL, NULL, NULL, NULL, '2020-09-21 11:33:46'),
(14, 1, 12321328, 'Maria Velota', '04148491448', NULL, NULL, NULL, NULL, '2020-09-21 11:37:46'),
(15, 1, 12321328, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-21 12:57:00'),
(16, 1, 12321328, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-21 13:50:19'),
(17, 1, 1232132, 'Maria Velota', '04148491448', NULL, NULL, NULL, NULL, '2020-09-21 14:02:33'),
(18, 1, 12321328, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-21 14:05:30'),
(19, 1, 12321328, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-21 14:12:25'),
(20, 1, 12321328, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-22 09:08:28'),
(21, 0, 12321328, 'Maria Velota', '04148491448', '232442', 'DHL', 'Callejon Gutierrez', 'Na', '2020-09-22 10:25:03'),
(22, 1, 12321328, 'Maria Velota', '04148491448', NULL, NULL, NULL, NULL, '2020-09-22 11:15:05'),
(23, 1, 12321328, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-23 12:08:46'),
(24, 1, 34424634, 'Maria Velota', '04148491448', NULL, NULL, NULL, NULL, '2020-09-25 19:27:25'),
(25, 1, 34424654, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-25 20:01:37'),
(26, 1, 12321328, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-09-25 20:12:34'),
(27, 1, 34424654, 'Maria Velota', '04148491448', NULL, NULL, NULL, NULL, '2020-09-25 20:15:44'),
(28, 1, 12321328, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-10-08 14:16:58'),
(29, 1, 12321328, 'Pablo Moya', '04148491448', NULL, NULL, NULL, NULL, '2020-10-09 09:37:54');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_departaments`
--

CREATE TABLE `sisg_departaments` (
  `id` int(11) NOT NULL,
  `description` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_departaments`
--

INSERT INTO `sisg_departaments` (`id`, `description`) VALUES
(1, 'Soporte'),
(2, 'Laboratorio'),
(3, 'Taller de Equipos'),
(4, 'HelpDesk'),
(5, 'Facturación y Cobranza'),
(6, 'Ventas'),
(7, 'Integración'),
(8, 'Almacen'),
(9, 'Producción'),
(10, 'Operaciones'),
(11, 'Servicio al Cliente'),
(12, 'Desarrollo e Insvestigación'),
(13, 'Presidencia');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_developersclients`
--

CREATE TABLE `sisg_developersclients` (
  `id` int(11) NOT NULL,
  `document` varchar(20) NOT NULL,
  `description` varchar(100) NOT NULL,
  `address` varchar(150) NOT NULL,
  `country` varchar(100) NOT NULL,
  `state` varchar(100) NOT NULL,
  `city` varchar(100) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `enable` tinyint(1) NOT NULL,
  `creation_date` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_developersclients`
--

INSERT INTO `sisg_developersclients` (`id`, `document`, `description`, `address`, `country`, `state`, `city`, `phone`, `email`, `enable`, `creation_date`) VALUES
(1, 'J308056014', 'SOLUCIONES EN INFORMATICA C.A.', 'AV. LIBERTADOR ENTRE CALLES 17 Y 18, NRO S/N, A MEDIA CUADRA DEL CC BABILON', 'Venezuela', 'Lara', 'Barquisimeto', '0251-2374212', 'seinca.opera.arodriguez@hotmail.com', 1, '2019-06-26 15:31:22'),
(2, 'J309056016', 'SIS Mexico C.A.', 'AV. MEXICO ENTRE CALLES 17 Y 18, NRO S/N', 'Venezuela', 'Carabobo', 'Valencia', '0256-2374212', 'sismex@gmail.com', 1, '2019-07-18 13:55:53'),
(3, 'P134239277', 'DETI Software C.A.', 'Calle 80 con #68 Barrio Puente Largo, bodega 20', 'Colombia', 'Cundinamarca', 'Bogotá D.C', '+57 322 8491444', 'detripos@hotmail.com', 1, '2019-07-18 13:54:54'),
(4, 'E145264614', 'Pablo Mendez', 'Calle 34 con Molinos', 'Colombia', 'Cundinamarca', 'Bogotá DC', '+57 322 8491444', 'dev@bitsamericas.com', 1, '2019-07-30 10:37:12'),
(6, 'P456241635', 'Pablo Mendez', 'Calle luna calle sol. AV 12.', 'Colombia', 'Antoquia', 'Medellin', '+57 3228491444', 'dev2@bitsamericas.com', 1, '2019-08-09 10:11:47');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_developersclientsusers`
--

CREATE TABLE `sisg_developersclientsusers` (
  `id` int(11) NOT NULL,
  `developersclientsId` int(11) NOT NULL,
  `userId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_developersclientsusers`
--

INSERT INTO `sisg_developersclientsusers` (`id`, `developersclientsId`, `userId`) VALUES
(1, 4, 36);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_distributors`
--

CREATE TABLE `sisg_distributors` (
  `id` int(11) NOT NULL,
  `idSA` int(11) NOT NULL,
  `rif` varchar(12) NOT NULL,
  `description` varchar(100) NOT NULL,
  `represent` varchar(40) NOT NULL,
  `address` varchar(150) NOT NULL,
  `country` varchar(100) NOT NULL,
  `state` varchar(100) NOT NULL,
  `city` varchar(100) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `nit` varchar(15) NOT NULL,
  `codeZone` varchar(10) NOT NULL,
  `nameSeller` varchar(50) NOT NULL,
  `rifSeller` varchar(15) NOT NULL,
  `phoneSeller` varchar(100) NOT NULL,
  `typeAgreement` varchar(80) NOT NULL,
  `enable` tinyint(1) NOT NULL,
  `creation_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_distributors`
--

INSERT INTO `sisg_distributors` (`id`, `idSA`, `rif`, `description`, `represent`, `address`, `country`, `state`, `city`, `phone`, `email`, `nit`, `codeZone`, `nameSeller`, `rifSeller`, `phoneSeller`, `typeAgreement`, `enable`, `creation_date`) VALUES
(1, 123456, 'J301920244', 'Sermateca, C.A.', 'Marcos Chang', 'Av. 4 Bella Vista, Nro. 58 A-127 Edif. Roraima PB- Maracaibo-Zulia', 'Venezuela', 'Zulia', 'Maraibo', '58 261 3541160', 'japonte@bitsamericas.com', 'J-30192024-4', '4002', 'María Mejía', 'J301920255', '+58 414 3541160', 'Transporte Express 21', 1, '2019-05-24 10:14:13'),
(2, 22000, 'J312171197', 'Bits Americas SAS Distribuidor', 'Oficina Admin', 'Av Fco. Miranda Callejon Gutierrez', 'Venezuela', 'Miranda', 'Caracas', '212 2564742', 'pmmoyapablo@gmail.com', '0000001', '123', 'Oficina', '000', '00000', 'NA', 1, '2019-06-26 00:00:00'),
(3, 110225, 'J555385359', 'Importadora Post 777 C.A', 'Luis Damiro Lucas', 'Avenida Casanova, Edf. Riva, Local 2-1. Planta Baja. Los Cortijos. Caracas ? Venezuela', 'Venezuela', 'Dtto Capital', 'Caracas', '+58-2123541161', 'ldimire@gmail.com', 'N123465600', '145', 'Luisa Le?n', 'V102385358', '0414 3541160', 'MRW', 1, '2019-06-25 14:56:13'),
(7, 11003, 'J875212448', 'Máquinas Fiscales 45 S.A', 'Juliana Torres', 'Av Pedro Jimenez con calle # 12.', 'Venezuela', 'Lara', 'Barquisimeto', '249 8754455', 'pmmoyapablo@gmail.com', '0090898797', '', 'Erlis Cariaco', '103', '414 45648781', '', 1, '2019-06-14 11:09:12'),
(8, 11007, 'J115212444', 'Representaciones Lomar, C.A.', 'Cristiano Ronaldo', 'Av Pedro Jimenez con calle # 12.', 'Venezuela', 'Lara', 'Barquisimeto', '249 8754455', 'pmmoyapablo@hotmail.com', '0090898797', '', 'Nataly Chacon', '104', '414 45648789', '', 1, '2019-06-14 11:55:16'),
(13, 11225, 'J312171198', 'The Facory HKA II', 'Ana Mujica', 'Calle Callejón Gutierre, Edf. Rivas', 'Venezuela ', 'Dtto Fed./Miranda', 'Caracas', '212 2455456', 'pmmoyapablo745@hotmail.com', '312171197', '', 'Oficina Venta TFHKA', '107', '0212-2020811', '', 1, '2019-12-11 16:19:02'),
(14, 12008, 'J212288460', 'Regitecnica Maracay, C.A. II', 'Maelo Ruiz', 'Calle Luna Calle Sol, con la esquina # 32.', 'Venezuela', 'Aragua', 'Aragua', '212 5421100', 'pmmoyapablo@hotmail.com', '6645411515', '', 'Oficina Venta TFHKA', '102', '0212-2020811', '', 1, '2019-12-11 16:25:17'),
(15, 12009, 'J212288461', 'Regitecnica Maracay, C.A. III', 'Maelo Ruiz', 'Calle Luna Calle Sol, con la esquina # 32.', 'Venezuela', 'Aragua', 'Aragua', '212 5421100', 'pmmoyapablo@hotmail.com', '6645411515', '', 'Oficina Venta TFHKA', '102', '0212-2020811', '', 1, '2019-12-11 16:29:00'),
(17, 16048, 'J402121750', 'DIMAICA SYSTEM, C.A.', 'SOBEIDA RANGEL', 'AV ,MONSEÑOR ZABALETA CC C.C ZABALETA NIVEL PB', 'Venezuela', 'Bolivar', 'Ciudad Guayana', '0286-923-6061', 'client16048@tfhka.com', 'J-40212175-0', '', 'Oficina Venta TFHKA', '03', '0212-2020811', '', 1, '2020-03-19 12:35:06'),
(18, 114084, 'J296898081', 'JF2 TECNOLOGIA INTEGRAL, C.A.', 'Jose Manuel Borelli', 'Calle Borges con 1era Transversal de Bello Monte Edif. Veron', 'Venezuela', 'Dtto Fed./Miranda', 'Caracas', '0212-7618721/311-2072/814-2442', 'client114084@tfhka.com', 'J-29689808-1', '', 'Oficina Venta TFHKA', '21', '0212-2020811', '', 1, '2020-03-19 13:41:08'),
(19, 295597754, 'J295597754', 'Servi Cash Electronic 421, C.A.', 'Christian', 'Av. Universidad CC Parque Carabobo Nivel 7 Local 708', 'Venezuela', 'Dtto Fed./Miranda', 'Caracas', '212 8801298', 'client295597754@tfhka.com', 'J-29559775-4', '', 'Oficina Venta TFHKA', '002', '0212-2020811', '', 1, '2020-03-19 14:11:33'),
(20, 110055, 'J311878467', 'L.C Servicios C.A', 'Leonardo Coscorrosa', 'CALLE AMPIES CASA 13 SECTOR SAN ANTONIO CORO', 'Venezuela', 'Falcon', 'Coro', '0268-2520150/0416-76897140', 'client110055@tfhka.com', 'J-31187846-7', '', 'Oficina Venta TFHKA', '02', '0212-2020811', '', 1, '2020-03-19 14:16:39'),
(21, 150570, 'J297787240', 'Star Sistemas, C.A.', 'CARLOS GOMEZ', 'CALLE 9 ESQUINA CARRERA 12 LOCAL  NRO. 8-112 NRO. 2', 'Venezuela', 'Tachira', 'San Cristobal', '0276-343-8471/0416-971-0083', 'client150570@tfhka.com', 'J-29778724-0', '', 'Oficina Venta TFHKA', '03', '0212-2020811', '', 1, '2020-03-19 14:23:33'),
(22, 110009, 'J308726273', 'Distribuidora Tecnologia y Oficina, C.A.', 'Constantino', 'Carrera 17 Nº26 Frente Al Mercado Nuevo', 'Venezuela', 'Monagas', 'San Felix De Monagas', '0291-6414766', 'client110009@tfhka.com', '0223708803', '', 'Oficina Venta TFHKA', '02', '0212-2020811', '', 1, '2020-03-26 11:36:40'),
(23, 110364, 'J296765200', 'Ingepos Soluciones, C.A', 'Francisco Pardo', 'Av. Francisco de Miranda Edif. Centro Seguros la Paz Piso 4', 'Venezuela', 'Dtto Fed./Miranda', 'Caracas', '0212-2395085 / 2377396', 'client110364@tfhka.com', 'J-29676520-0', '', 'Oficina Venta TFHKA', '21', '0212-2020811', '', 1, '2020-03-26 11:38:09'),
(24, 110103, 'J295232152', 'DACOM, C.A.', 'Raúl Boucchechter (socio)', 'AV INTERCOMUNAL SANTIAGO MARIÑO CC INTERCOMUNAL CENTER', 'Venezuela', 'Aragua', 'Cagua', '0243-267-9924/269-3244', 'client110103@tfhka.com', 'J-29523215-2', '', 'Oficina Venta TFHKA', '03', '0212-2020811', '', 1, '2020-03-26 11:40:00'),
(25, 110162, 'J293987130', 'Impresoras Fiscales 421, C.A.', 'Efrain Ferreira', 'Calle Callejon Gutierrez Edif. Riva. Piso 01 LOCAL P1-2C', 'Venezuela', 'Dtto Fed./Miranda', 'Caracas', '0212- 237-5132/237-5010', 'client110162@tfhka.com', '', '', 'Oficina Venta TFHKA', '01', '0212-2020811', '', 1, '2020-03-26 11:49:30'),
(26, 110392, 'J295715579', 'T3CH Sistemas, C.A', 'DENIS RODRIGUEZ', 'AV ROMULO GALLEGO EDIF TORRE SAMAN PISO 6 OFIC 61', 'Venezuela', 'Dtto Fed./Miranda', 'Caracas', '0212-318-4051/318-4052', 'client110392@tfhka.com', 'J-29571557-9', '', 'Oficina Venta TFHKA', '03', '0212-2020811', '', 1, '2020-05-08 10:05:33'),
(27, 412313789, 'J412313789', 'SUMINISTROS MCI 2019, C.A.', 'CECIL AUGUSTO CRESPO', 'CR 15 CON CALLE 38, LOCAL NRO. 38-58 ZONA CENTRO', 'Venezuela', 'Lara', 'Barquisimeto', '0251-9350458', 'client412313789@tfhka.com', 'J-41231378-9', '', 'Oficina Venta TFHKA', '15', '0212-2020811', '', 1, '2020-05-08 10:18:18'),
(28, 110263, 'J294170161', 'Ofimaxvic, C.A', '', 'Calle Páez Este, Casa No. 5-03, Urb. Bolivar Norte , La', 'Venezuela', 'Aragua', 'La Victoria', '0244-3216572', 'client110263@tfhka.com', 'J-29417016-1', '', 'Oficina Venta TFHKA', '03', '0212-2020811', '', 1, '2020-05-12 14:22:05'),
(29, 110436, 'J301187407', 'C.P.L.G. Consultores, C.A', 'Ing. Luis Salinas', 'Av. Francisco de Miranda Centro Empresarial Don', 'Venezuela', 'Dtto Fed./Miranda', 'Caracas', '0212-2393077', 'client110436@tfhka.com', 'J-30118740-7', '', 'Oficina Venta TFHKA', '24', '0212-2020811', '', 1, '2020-05-12 15:29:04'),
(30, 110033, 'J316434168', 'Bytesource Systems, C.A.', 'Juan Eduardo Labraña', 'Av. Libertador Con Santiago De Chile Edf. Freites, Piso 10', 'Venezuela', 'Dtto Fed./Miranda', 'Miranda', '0212-794-29-99/793-45.77', 'client110033@tfhka.com', '', '', 'Oficina Venta TFHKA', '02', '0212-2020811', '', 1, '2020-05-12 15:30:39'),
(31, 110245, 'J296297541', 'R.S.F. Sistema y Computación, C.A', 'Joel Naranjo', 'Av. Urdaneta Cruce con calle Rondon Edif. Caicara Piso', 'Venezuela', 'Carabobo', 'Valencia', '0241-858-3615 /858-3430', 'client110245@tfhka.com', 'J-29629754-1', '', 'Oficina Venta TFHKA', '02', '0212-2020811', '', 1, '2020-05-14 14:27:14'),
(32, 110225, 'J309894250', 'Advanced  Pos Technology, C.A.', 'Ricardo Abdel Comas', 'Av.Francisco de Miranda, Torre Profesional La California', 'Venezuela', 'Dtto Fed./Miranda', 'Caracas', '212 2375371', 'client110225@tfhka.com', 'J-30989425-0', '', 'Oficina Venta TFHKA', '22', '0212-2020811', '', 1, '2020-07-21 13:29:08'),
(33, 110042, 'J294451055', 'Sistemas de Oficina Maraisa, C.A.', 'Constantino', 'Calle 12, Antigua Calle Miranda Nro. S/N Sector Mercado', 'Venezuela', 'Monagas', 'Maturin', '0291-6414766', 'client110042@tfhka.com', 'J-29445105-5', '', 'Oficina Venta TFHKA', '02', '0212-2020811', '', 1, '2020-07-22 09:00:35'),
(34, 110595, 'J306754601', 'Servicios de Computacion 2010, C.A', 'Aldrin Alvarez', 'Av. Romulo Gallegos Edf. Johnson y Jhnson piso 4', 'Venezuela', 'Dtto Fed./Miranda', 'Caracas', '0212-239-4065 /237-5589', 'client110595@tfhka.com', 'J-30675460-1', '', 'Oficina Venta TFHKA', '21', '0212-2020811', '', 1, '2020-07-22 09:15:28');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_distributorsproviders`
--

CREATE TABLE `sisg_distributorsproviders` (
  `id` int(11) NOT NULL,
  `distributorsId` int(11) NOT NULL,
  `providerId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_distributorsproviders`
--

INSERT INTO `sisg_distributorsproviders` (`id`, `distributorsId`, `providerId`) VALUES
(1, 1, 2),
(10, 2, 1),
(3, 3, 1),
(4, 3, 2),
(7, 7, 1),
(8, 8, 1),
(11, 14, 1),
(12, 15, 1),
(14, 17, 1),
(15, 18, 1),
(16, 19, 2),
(17, 20, 1),
(18, 21, 1),
(19, 22, 1),
(20, 23, 1),
(21, 24, 1),
(22, 25, 1),
(23, 26, 1),
(24, 27, 1),
(25, 28, 1),
(26, 29, 1),
(27, 30, 1),
(28, 31, 1),
(29, 32, 1),
(30, 33, 1),
(31, 34, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_distributorsusers`
--

CREATE TABLE `sisg_distributorsusers` (
  `id` int(11) NOT NULL,
  `distributorsId` int(11) NOT NULL,
  `userId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_distributorsusers`
--

INSERT INTO `sisg_distributorsusers` (`id`, `distributorsId`, `userId`) VALUES
(4, 1, 19),
(2, 2, 27),
(3, 8, 28),
(5, 15, 58),
(6, 17, 60),
(7, 18, 61),
(8, 19, 62),
(9, 20, 63),
(10, 21, 64),
(11, 22, 65),
(12, 23, 66),
(13, 24, 67),
(14, 25, 68),
(15, 26, 70),
(16, 27, 71),
(17, 28, 72),
(18, 29, 73),
(19, 30, 74),
(20, 31, 75),
(21, 32, 76),
(22, 33, 77),
(23, 34, 78);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_employees`
--

CREATE TABLE `sisg_employees` (
  `id` int(11) NOT NULL,
  `supervitorId` int(11) NOT NULL,
  `rif` varchar(12) NOT NULL,
  `code` varchar(20) NOT NULL,
  `description` varchar(150) NOT NULL,
  `departamentId` int(11) NOT NULL,
  `chargueId` int(11) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `enable` tinyint(1) NOT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_employees`
--

INSERT INTO `sisg_employees` (`id`, `supervitorId`, `rif`, `code`, `description`, `departamentId`, `chargueId`, `email`, `phone`, `enable`, `creation_date`) VALUES
(0, 0, 'V000000000', '0001', 'Natalia Soto', 13, 20, 'nsoto@bitsamericas.com', '+5800000000', 1, '2019-09-05 16:28:39'),
(1, 0, 'V145264614', '10001', 'Pablo Moya', 12, 27, 'pmoya@bitsamericas.com', '+57 322 8491444', 1, '2019-08-16 10:40:09'),
(2, 1, 'V123456789', '10051', 'Luis Marchan', 12, 28, 'lmarchan@bitsamericas.com', '+58 414 7491454', 1, '2019-08-09 09:57:20'),
(3, 0, 'V124567005', '10002', 'Raul Moreno', 1, 3, 'rmoreno@bitsamericas.com', '+58 414 5491477', 1, '2019-08-14 17:17:26'),
(4, 0, 'V114567009', '10003', 'Raul Valderrama', 11, 1, 'rvalderrama@bitsamericas.com', '+58 414 3451478', 1, '2019-08-14 17:25:27'),
(6, 5, 'V253456984', '10098', 'Paloa Aguirre', 7, 6, 'paguirre@bitsamericas.com', '+58 412 9691468', 1, '2019-08-14 17:24:45'),
(7, 3, 'V103456933', '10102', 'Mayra Ramirez', 1, 7, 'mramirez@bitsamericas.com', '+58 414 7691468', 1, '2019-08-14 17:26:03'),
(8, 4, 'V133456956', '10012', 'Nelida Salazar', 4, 2, 'nsalazar@bitsamericas.com', '+58 414 7191434', 1, '2019-08-15 09:21:00'),
(9, 8, 'V233456959', '10212', 'Zoraliz Bolivar', 4, 13, 'zbolivar@bitsamericas.com', '+58 412 7191438', 1, '2019-08-15 09:25:27'),
(10, 4, 'V133456950', '10013', 'Isleye Martinez', 3, 11, 'ycmartinez@bitsamericas.com', '+58 412 9991438', 1, '2019-08-15 09:31:35'),
(11, 10, 'V233456950', '10313', 'Jesus Leal', 3, 12, 'jlealz@bitsamericas.com', '+58 416 2991438', 1, '2019-08-15 09:34:37'),
(12, 0, 'V133457750', '10113', 'Douglas Montilla', 8, 21, 'dmontilla@bitsamericas.com', '+58 412 3991438', 1, '2019-08-15 09:37:41'),
(13, 12, 'V183457751', '10117', 'Eduardo Santana', 8, 22, 'esantana@bitsamericas.com', '+58 414 3991439', 1, '2019-08-15 09:38:53'),
(14, 10, 'V283457752', '10317', 'Yordano Gil', 3, 16, 'ygil@bitsamericas.com', '+58 412 5991439', 1, '2019-08-15 09:45:56'),
(15, 0, 'V183457752', '10127', 'Jackeline Centeno', 5, 9, 'jcenteno@bitsamericas.com', '+58 414 5991436', 1, '2019-08-15 09:49:33'),
(16, 15, 'V173457752', '10129', 'Pedro Fanay', 5, 10, 'pfanay@bitsamericas.com', '+58 414 1991436', 1, '2019-08-15 09:55:07'),
(17, 10, 'V154555220', '2001', 'Pablo Mendez', 3, 12, 'pmendez@tfhka.com', '+58 412 8491448', 1, '2019-08-22 15:32:23');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_employeesusers`
--

CREATE TABLE `sisg_employeesusers` (
  `id` int(11) NOT NULL,
  `employeeId` int(11) NOT NULL,
  `userId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_employeesusers`
--

INSERT INTO `sisg_employeesusers` (`id`, `employeeId`, `userId`) VALUES
(1, 7, 41),
(2, 6, 42),
(3, 3, 44),
(4, 1, 1),
(5, 2, 45),
(6, 8, 46),
(7, 9, 47),
(8, 4, 48),
(9, 10, 49),
(10, 11, 50),
(11, 12, 51),
(12, 13, 52),
(13, 14, 53),
(14, 15, 54),
(15, 16, 55),
(16, 17, 56);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_finalsclients`
--

CREATE TABLE `sisg_finalsclients` (
  `id` int(11) NOT NULL,
  `rif` varchar(10) CHARACTER SET latin1 NOT NULL,
  `description` varchar(100) CHARACTER SET latin1 NOT NULL,
  `name` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `lastName` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `phone` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `email` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `fiscalAddress` varchar(150) CHARACTER SET latin1 DEFAULT NULL,
  `enable` tinyint(1) NOT NULL,
  `creation_date` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `sisg_finalsclients`
--

INSERT INTO `sisg_finalsclients` (`id`, `rif`, `description`, `name`, `lastName`, `phone`, `email`, `fiscalAddress`, `enable`, `creation_date`) VALUES
(1, 'J309568590', 'Cosmeticos Lolita C.A', 'Erika', 'Dominguez', '0251-2374212', 'seinca.opera.arodriguez@hotmail.com', 'Calle Miranda, esquina 8. Los Castores. San Antonio los Altos. Edo. Miranda', 1, '2019-07-30 13:19:40'),
(2, 'V123456789', 'Contribuyente Ejemplo S.A', 'Pepito', 'Bolsa Amarilla', '23528454500', 'clientp23@tfhka.com', 'AV Barath con punto 9', 1, '2019-07-31 17:00:01'),
(3, 'J000999888', 'Calzados Pelua C.A', NULL, NULL, NULL, NULL, NULL, 1, '2019-07-31 17:01:01'),
(4, 'J333999848', 'La Taguarita del Este', NULL, NULL, NULL, NULL, NULL, 1, '2019-07-31 17:01:24'),
(6, 'J314956701', 'COMERCIAL MARLON,C.A. ', NULL, NULL, NULL, NULL, NULL, 1, '2019-08-06 16:50:05'),
(7, 'E821911691', 'MERCEDES J. PALMA M. DE ALAVA', NULL, NULL, NULL, NULL, NULL, 1, '2019-08-06 16:51:41'),
(8, 'J000129266', 'NESTLE VENEZUELA, S.A. ', NULL, NULL, NULL, NULL, NULL, 1, '2019-08-27 12:12:05'),
(10, 'J310538247', 'MAKRO COMERCIALIZADORA PARAGUANA S.A ', NULL, NULL, NULL, NULL, NULL, 1, '2019-09-20 11:14:56'),
(17, 'V145264614', 'PABLO EUGENIO MOYA PINANGO ', NULL, NULL, NULL, NULL, ' AV NO INDICA EDIF 2 BLOQUE 16 PISO 2 APT 0207 URB RUIZ PINEDA, SECTOR UD7 CARACAS DISTRITO CAPITAL ZONA POSTAL 1100  18/03/2019', 1, '2020-02-24 15:07:34'),
(31, 'V030110508', 'EZEQUIELA ELVIGIA PINANGO DE MOYA ', 'EZEQUIELA', NULL, '+58 212 3725216', 'pmmoyapablo@hotmail.com', NULL, 1, '2020-02-25 20:17:54'),
(36, 'V205405662', 'GLORIA ELENA NOGUERA ASUAJE ', NULL, NULL, NULL, NULL, ' AV LECUNA EDIF TORRION PISO 1 APT 4 URB EL CONDE CARACAS DISTRITO CAPITAL ZONA POSTAL 1010  09/07/2021', 1, '2020-02-26 14:48:03'),
(38, 'J401604196', 'PROSEIN ACARIGUA C.A ', NULL, NULL, NULL, NULL, ' AV CIRCUNVALACION 1 SUR, ENTRE CALLES 3 Y 4 LOCAL PROSEIN NRO S/N BARRIO SAN ANTONIO ACARIGUA PORTUGUESA ZONA  30/07/2022', 1, '2020-02-26 14:51:26'),
(41, 'J403306257', 'GADEL ADVENTURE C.A ', NULL, NULL, NULL, NULL, ' AV LOS AVIADORES CC LOS AVIADORES NIVEL B LOCAL L-250 v u ACION SECTOR PALO NEGRO PALO NEGRO ARAGUA ZONA POSTAL 2117  05/11/2022', 1, '2020-02-26 16:20:57'),
(42, 'V126399304', 'ANDRES ELOY CAMPEROS TORREALBA ', NULL, NULL, NULL, NULL, ' AV PERIMETRAL DE CUA, ANTERIORMENTE LLAMADA AV LOS PROCERES, CARRETERA CUA-OCUMARE DEL TUY EDIF A-6 PISO 4 APT A-6 P42  04/04/2022', 1, '2020-02-26 16:21:44'),
(43, 'J313882216', 'ARV ALIMENTOS, C.A. ', NULL, NULL, NULL, NULL, ' AV PRICA CC CIUDAD TRAKI NIVEL PB LOCAL F-13 SECTOR CONEJEROS PORLAMAR NUEVA ESPARTA ZONA POSTAL 6301  18/06/2022', 1, '2020-02-26 19:17:26'),
(44, 'J413145766', 'ILUMI LIFE C.A ', NULL, NULL, NULL, NULL, ' CALLE LOPEZ AVELEDO C/C CUARTA TRANSVERSAL QTA JAMBAL NRO 1 URB CALICANTO MARACAY ARAGUA ZONA POSTAL 2102  24/10/2022', 1, '2020-03-04 18:07:11'),
(45, 'J296022062', 'CASCANUECES C.A. (CASCANUECES C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(46, 'J311622454', 'OPTICA MIS OJOS CA (ÓPTICA MIS OJOS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(47, 'J306545603', 'CONSULTORIO OPTOMETRICO OFTALMOLOGICO BEHRENS, C.A. (CONSULTORIO OPTOMETRICO OFTALMOLÓGICO BEHRENS, ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(48, 'J307812486', 'ALMA CERAMICA, C.A. (ALMA CERAMICA, C.A.     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(49, 'J293717957', 'VARIEDADES SALOMON,C.A (VARIEDADES SALOMON, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(50, 'J301111419', 'EL BODEGON DE WILLIAM C.A (ELBODEGON DE WILLIAM COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(51, 'J316936236', 'MISTER SHAWARMA,C.A. (MISTER SHAWARMA,C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(52, 'V158395777', 'GIOVANNI OROZCO DE QUINTERO ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(53, 'J070418800', 'ELECTRONICA SUEM C.A (ELECTRONICA SUEM, COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(54, 'J297523537', 'INVERSIONES MULTIPLES HC, SOCIEDAD ANONIMA (INVERSIONES MULTIPLES HC, SOCIEDAD ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(55, 'J296934304', 'INVERSIONES DIGNA RIQUETH SPA,C.A. (INVERSIONES DIGNA RIQUETH SPA,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(56, 'J311178988', 'TASCA RESTAURANT LA GRAN VICTORIA, C.A. (TASCA RESTAURANT A GRAN VICTORIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(57, 'J297872701', 'DISTRIBUIDORA Y COMERCIALIZADORA MARACAIBO C.A. (DISTRIBUIDORA Y COMERCIALIZADORA MARACAIBO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(58, 'V128478694', 'JAIRO ALEXANDER HEVIA URBINA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(59, 'V130983681', 'MARIA ENRIQUETA LEON PEREZ  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(60, 'J312443499', 'CONFECCIONES AG, C.A. (DF)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(61, 'J312492449', 'ESPACIO CORPORAL, C.A.   ASOCIADOS (KJJ)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(62, 'J306685758', 'SUPER CONFITERIA NUEVA POPULAR,C.A. (SUPER CONFITERIA LA NUEVA POPULAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(63, 'J297615768', 'AUTOMERCADO LU, C.A. (AUTOMERCADO LU,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(64, 'J308609528', 'COMERCIAL FENG C A (COMERCIAL FENG, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(65, 'J297679618', 'FERREAUTOS MIKI C.A (FERREAUTOS MIKI C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(66, 'J303485596', 'COMERCIAL LOS TACHINES CA (COMERCIAL LOS TACHINES C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(67, 'J297915524', 'PIÑATERIA Y CONFITERIA LA FIESTA C.A (PIÑATERIA Y CONFITERIA LA FIESTA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(68, 'J296320110', 'AUTOREPUESTOS PLAZARAURE C.A. (AUTOREPUESTOS PLAZARAURE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(69, 'J316181413', 'BELLA DAMA BOUTIQUE CA (BELLA DAMA BOUTIQUE C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(70, 'J316647340', 'ATUENDOS, C.A. (ATUENDOS, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(71, 'J311058214', 'AFLORA FLOWER MARKET C.A. (AFLORA FLOWER MARKET,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(72, 'J294241727', 'ALE BIJOUX, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(73, 'J003265683', 'AMATO CAÑIZALEZ PRODUCCIONES 35 C.A. (AMATO CAÑIZALEZ PRODUCCIONES 35 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(74, 'J312763434', 'OKEY FOTOS 21 C.A. (X)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(75, 'J308525294', 'EVENTOS LOS ROTA C.A (EVENTOS LOS ROTA, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(76, 'J295515103', 'FERREPUNTO  2008 C.A. (FERREPUNTO  2008 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(77, 'J001102540', 'COCINAS KAPECAL, C.A (COCINAS KAPECAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(78, 'J002248440', 'INVERSIONES LA CITA SRL (INVERSIONES LA CITA, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(79, 'V076835183', 'ALEX R COHEN C ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(80, 'J311862609', 'DECORACIONES DECO HIPPO 19, C.A. (DECORACIONES DECO HIPPO 19 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(81, 'V098062641', 'ENRIQUE FERNANDO DE FREITAS RODRIGUEZ    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(82, 'J085015027', 'CONCRETERA FALCON C.A (CONCRETERA FALCON C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(83, 'J307128461', 'MULTISERVICIOS DON EUSEBIO, C.A. (MULTISERVICIO  DON EUSEBIO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(84, 'J300640019', 'CAUCHOS LOS OLIVARES C A (CAUCHOS LOS OLIVARES C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(85, 'J300878015', 'MI CAUCHO C A (MI CAUCHO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(86, 'J308647578', 'SUPLID DE MATER Y SERV INDUSTRIALES SUMASI, C.A (SUPLID DE MATER Y SERV INDUSTRIALES SUMASI, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(87, 'J309188127', 'DISTRIBUIDORA RODRIGUEZ Y FREITAS DE PARAGUANA, C.A. (DISTRIBUIDORA RODRIGUEZ Y FREITAS DE PARAGUANA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(88, 'J095043347', 'DISTRIBUIDORA INDUSTRIAL DEL SUR C A (DISTRIBUIDORA INDUSTRIAL DEL SUR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(89, 'J309481371', 'SERVICIOS DE TRANSPORTE Y MTTO.RUBYS, C.A. (SERVICIOS DE TRANSPORTE Y MANTENIMIENTO RUBYS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(90, 'J296950482', '\"SUPER PAPEL GUAYANA, C.A.\" (SUPER PAPEL GUAYANA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(91, 'J294929630', 'CAUCHOS LA EXCELENCIA, C.A (CAUCHOS LA EXCELENCIA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(92, 'J295251556', 'AMORTIGUADORES Y REPUESTOS 3.J.CA (AMORTIGUADORES Y REPUESTOS 3.J.CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(93, 'J306011072', 'ABRAS, CA (ABRAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(94, 'J296020019', 'J.J  AMORTIGUADORES COMPAÑIA ANONIMA. (J.J. AMORTIGUADORES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(95, 'J305715106', 'REPUESTOS Y ACCESORIOS EL VENDEDOR, C.A. (REPUESTOS Y ACCESORIOS EL VENDEDOR,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(96, 'J306052410', 'SUMEQUI CA (SUMEQUI CA  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(97, 'J306434046', 'COMERCIAL SUMECO CA (COMERCIAL SUMECO C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(98, 'J308597376', 'DISTRIBUIDORA GREBETT, C.A. (DISTRIBUIDORA GREBETT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(99, 'J295360703', 'FARMAEXITO, C.A (FARMAEXITO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(100, 'J312018267', 'IMPORTADORA TELEROBLE MOTOR S C.A (IMPORTADORA TELEROBLE MOTORS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(101, 'J095024296', 'UNICO MOTOR C A (UNICO MOTOR C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(102, 'J095017184', 'RECTI MOTORES GUAYANA REMOGUACA (REMOGUACA C A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(103, 'J304763581', 'MULTISERVICIOS EL PASEO CA (MULTISERVICIOS EL PASEO CA    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(104, 'J316718255', 'INVERSIONES DAVID CAR,C.A. (INVERSIONES DAVID CAR,C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(105, 'J306131426', 'INVERSIONES RUTA UNO, CA (INVERSIONES RUTA UNO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(106, 'J294362052', 'ZONA INFANTIL,C.A. (ZONA INFANTIL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(107, 'J313759830', 'PINTURAS A.G., C.A. (PINTURAS AG, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(108, 'J304184921', 'INVERSIONES LA FERIA SAN FELIX ,C.A. (LA FERIA DE LA PINTURA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(109, 'J296286167', '\"INVERSIONES AUSTRAL, C.A.\" (INVERSIONES AUSTRAL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(110, 'J294996175', 'REPUESTOS TAXICAR C.A (REPUESTOS TAXICAR C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(111, 'J310207798', 'DRY WALL, C,A (DRY WALL, C.A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(112, 'J303225586', 'BIG SHOP, CA (BIG SHOP, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(113, 'J309539957', 'TOYO CENTER, C.A (TOYO CENTER, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(114, 'J293618797', 'EL GLAMOUR DE YENNY C.A (\"EL GLAMOUR DE YENNY, C.A.\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(115, 'J304712308', '\"TORNILLOS DE  GRADO DI  BERARDINIS, C.A.\", (TORNILLOS D G DI BERARDINIS CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(116, 'J306427244', 'FARMACIA SAN PEDRO, C.A (FARMACIA SAN PEDRO C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(117, 'J305090734', 'REPRESENTACIONES C E A CA (REPRESENTACIONES C E A CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(118, 'J300964299', 'PAPELERIA EL CREYON C A (PAPELERIA EL CREYON C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(119, 'J095161790', 'FERRETERIA SAN JUDAS TADEO C A (FERRETERIA SAN JUDAS TADEO C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(120, 'J301947371', 'STAR SPORT C A (STAR SPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(121, 'J313537152', 'INVERSIONES CABARELA COMPAÑIA ANONIMA (INVERSIONES CABARELA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(122, 'J095116816', '\"ORINOCO INDUSTRIAL S A\" (ORINOCO INDUSTRIAL SA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(123, 'J095020789', 'TORNILLERIA DEL SUR SRL (TORNILLERIA DEL SUR SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(124, 'J309292633', 'ME CONSULTORIA Y CAPACITACION EMPRESARIAL, C.A (ME CONSULTORIA Y CAPACITACION EMPRESARIAL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(125, 'J095111750', 'ALTECA, C.A. (ALTECA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(126, 'J312591404', 'INVERSIONES FERREMONCA, C.A (INVERSIONES FERREMONCA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(127, 'J312592818', 'INVERSIONES AFIANSSA, S.A (INVERSIONES AFIANSSA,S.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(128, 'J303793266', '\"CRISIMAR FLORES Y ESTILOS, C.A.\" (CRISIMAR FLORES Y ESTILOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(129, 'J315962560', 'INVERSIONES BLUE, C.A. (INVERSIONES BLUE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(130, 'J308176087', 'AUTOPARTES REICAR RACING, C.A. (AUTOPARTES REICAR RACING, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(131, 'J315891514', 'SERVICIOS Y REPUESTOS ENMANUEL, C.A. (SERVICIOS Y REPUESTOS ENMANUEL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(132, 'J307283637', '\"COMERCIAL LOS CACIQUES, COMPAÑIA ANONIMA\" (\"COMERCIAL LOS CACIQUES, COMPAÑIA ANONIMA\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(133, 'J303699740', 'CALZADOS MARIANGEL CA (CALZADOS MARIANGEL CA   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(134, 'J303114300', '\"AGROPECUARIA LOS NARANJOS, C.A.\" (\"AGROPECUARIA LOS NARANJOS, C.A.\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(135, 'J308452378', 'AUTOS REPUESTOS AFAMIA CA (AUTO REPUESTOS AFAMIA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(136, 'J300901858', '\"RESTAURANT CLUB CAMPESTRE MARHUANTA, C.A. (\"RESTAURANT CLUB CAMPESTRE MARHUANTA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(137, 'J306867872', 'DISTRIBUIDORA Y SERVICIO TECNICO PUNTO SHOP, C.A. (DISTRIBUIDORA Y SERVICIO TECNICO PUNTO SHOP, C.A.', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(138, 'J303252273', 'TORNILLERIA VISTA AL SOL C.A. (TORNILLERIA VISTA AL SOL C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(139, 'J305189790', 'LAFONF AUTO PARTS, C.A. (LAFONF AUTOPARTS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(140, 'J293873770', 'PITSTOP RECARGADO, C.A. (PITSTOP RECARGADO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(141, 'V053406013', 'CARMEN MARIA APONTE DE AULAR', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(142, 'E822468791', 'WEIZHAN LIANG  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(143, 'J295807694', 'FERRETERIA EL CINCEL,C.A (FERRETERIA EL CINCEL,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(144, 'J315718960', 'VERBANO, C.A. (VERBANO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(145, 'J309812297', 'REPUESTOS BELLATRIX C.A (REPUESTOS BELLATRIX C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(146, 'J314972340', 'SUMINISTROS DE MATERIALES BUENA VISTA CA (SUMINISTROS DE MATERIALES BUENA VISTA CA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(147, 'J316057720', 'BOGOTA MODA, C.A (BOGOTA MODA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(148, 'J296442207', 'READY TO WEAR, C.A (READY TO WEAR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(149, 'J095130061', '\"AUTOREPUESTOS CARIBE, COMPAÑIA ANONIMA\" (\"AUTOSREPUESTOS CARIBE,  COMPAÑIA ANONIMA\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(150, 'J303913733', 'INVERSIONES TWISTER CA (INVERSIONES TWISTER, C.A. (BAR RESTAURANT GRAN FURAMA))', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(151, 'J095124819', 'ELECTRO REPUESTOS CARONI C A (ELECTRO REPUESTOS CARONI C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(152, 'J310490996', 'GRUPO GUAYANA, S.A. (GRUPO GUAYANA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(153, 'J302464633', 'CORPORACION Z.L.G.,S.A. (CORPORACION Z.L.G S.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(154, 'J294794610', 'DECO-ORIENTE, C.A. (DEOCA) (DECO-ORIENTE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(155, 'J293938929', 'FERRETERIA GEORGES C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(156, 'V118968332', 'MORAIMA COROMOTO UTILLA  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(157, 'J310129703', 'COMERCIALIZADORA GPB VALERA, C.A. (COMERCIALIZADORA GPB VALERA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(158, 'J316353796', 'ACCESORIOS VALERA C A (ACCESORIOS VALERA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(159, 'V205317097', 'FABIO CARVAJAL QUINTERO  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(160, 'J301332920', 'INVERSIONES 127 C.A. (INVERSIONES 127, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(161, 'J308295493', 'INVERSIONES VILLA PARAISO,  C.A (AGROPECUARIA ENKIDU C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(162, 'J090161635', 'CAUCHOS MIRO, C.A. (CAUCHOS MIROS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(163, 'J305841519', 'DISTRIBUIDORA AGRICOLA EL RESGUARDO, SOCIEDAD ANONIMA (DISTRIBUIDORA AGRICOLA EL RESGUARDO, SOCIEDAD', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(164, 'J317146298', 'FERRETERIA EL MEJOR PRECIO, C.A. (FERRETERIA EL MEJOR PRECIO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(165, 'J315336510', '\"J.J.  BARRON, C.A.\" (\"J.J  BARRON, C.A.\"    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(166, 'J313280178', 'AGRO CORDILLERA C A (AGRO CORDILLERA C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(167, 'J310837821', 'PENCO TRUJILLO, C.A (PENCO TRUJILLO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(168, 'J090051287', 'FERRETERIA PENSO SRL (FERRETERIA PENSO SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(169, 'J306792139', 'CAPINTOR LA PLATA, C.A (CAPINTOR LA PLATA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(170, 'J304774443', 'PENCO LA PLATA COMPAÑIA ANONIMA (PENCO LA PLATA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(171, 'J304065426', 'SUPLIDORA PENSO BOCONO CA (SUPLIDORA PENSO BOCONO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(172, 'J302319900', 'SUPLIDORA PENSO, C.A. (PENCO CA) (SUPLIDORA PENSO,C.A.(PENCO CA))', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(173, 'J307789050', 'PENCO  CARS COMPAÑIA ANONIMA (PENCO  CARS COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(174, 'J306280235', 'CAPINTOR EL VIGIA  COMPAÑIA ANONIMA (CAPINTOR EL VIGIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(175, 'J090026452', 'FERREACRILICOS VALERA C A (FERREACRILICOS VALERA C A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(176, 'J090012010', 'CASA DEL PINTOR VALERA C A (CASA DEL PINTOR VALERA C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(177, 'J311082212', 'PENCO TIMOTES, C.A. (PENCO TIMOTES, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(178, 'J311674659', 'CONSTRUPENCO, C.A. (CONSTRUPENCO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(179, 'J312748117', 'PLANET IMPORT, C.A. (PLANET IMPORT, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(180, 'J293840155', 'INVERSIONES J.M. 96,C.A. (INVERSIONES J.M.96,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(181, 'J304008066', 'DISTRIBUIDORA DE LUBRICANTES LOS GALLEGOS, C.A. (DISTRIBUIDORA DE LUBRICANTES LOS GALLEGOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(182, 'J302621135', 'DISTRIBUIDORA ZIMAFER CA (DISTRIBUIDORA ZIMAFER, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(183, 'J296010021', 'FERRETERIA EL CONSEJO 2008, C.A. (FERRETERIA EL CONSEJO 2008, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(184, 'J294257704', 'AUTO REPUESTOS MI JEEP 2.000, C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(185, 'J310473129', 'LA LLAVE DORADA, C.A. (LA LLAVE DORADA, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(186, 'J309153595', 'COSMETICOS PROFESIONALES CARLA C.A. (COSMETICOS PROFESIONALES CARLA, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(187, 'J302468795', 'QUIROVIC S.R.L. (QUIROVIC S.R.L.   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(188, 'J306088261', 'MONIX C.A (MONIX C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(189, 'V120618845', 'JOAO MANUEL DE ABREU GONCALVES\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(190, 'J295267924', 'COMERCIAL PATRONA DE ORIENTE C.A. (COMERCIAL PATRONA DE ORIENTE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(191, 'J315216035', 'AUTO LAVADO VICTORIA SPLASH, C.A (AUTOLAVADO VICTORIA SPLASH, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(192, 'V111774184', 'JOSEFINA GOMEZ ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(193, 'J312729791', 'CERAMICA DON JOSE,C.A. (CERAMICA DON JOSE,C.A.  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(194, 'J295655681', 'BUONA PASTA RESTAURANT,  C.A (BUONA PASTA RESTAURENT C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(195, 'J309961659', '\" LCA SOLUTIONS, C.A. \" (\" LCA SOLUTIONS, C.A. \")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(196, 'J075249720', 'NOVEDADES JENNYMAR S R L (\"NOVEDADES JENNI MAR S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(197, 'J294631401', 'DESECHABLES DONDE MIGUEL, C.A. (DESECHABLES DONDE MIGUEL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(198, 'V132404786', 'JULIETA ALVAREZ ALFONSO  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(199, 'J314669893', 'INVERSIONES ROMACA 72, C.A. (INVERSIONES ROMACA 72, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(200, 'J313125849', 'INVERSIONES MI RETIRO C.A (INVERSIONES MI RETIRO )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(201, 'V085872687', '\"BAZAR SURTI HOGAR F.P.\" JACINTO DE BAPTISTA MARIA NELLY   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(202, 'J305294291', 'INVERSIONES GOMEZ,C.A. (INVERSIONES GOMEZ,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(203, 'J302720958', 'AUTO ALARMAS VICTORIA CAR`S C A (AUTO ALARMAS VICTORIA CARS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(204, 'V122330288', 'DALILA VANESSA MORILLO NAVAS', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(205, 'J295775440', 'COMERCIALIZADORA T.S. C.A. (COMERCIALIZADORA T.S. C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(206, 'V103610733', 'YULYMAR RODRIGUEZ ARGUETA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(207, 'V061198055', 'MARIA INMACULADA ACOSTA PADRON\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(208, 'J296706816', '\"JUANCHO´S  CAFÉ, C.A\" (¿JUANCHO´S  CAFÉ, C.A¿  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(209, 'V036535055', 'TAMES DE VILLARROEL ARSELINA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(210, 'J294940218', 'INVERSIONES PACARAIMA,C.A. (INVERSIONES PACARAIMA,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(211, 'J296756350', 'INVERSIONES L Y M 2009 S.R.L. (INVERSIONES L Y M 2009 S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(212, 'J308108030', 'EL OSO FELIZ, C.A. (EL OSO FELIZ)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(213, 'V056244073', 'HERMENEGILDO ALCANTARA CAMACHO\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(214, 'J296677557', 'CONTRALUZ,  C.A. (CONTRALUZ,  C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(215, 'J294710085', 'FRENOS JULIO, C. A. (FRENOS JULIO, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(216, 'V003254042', 'JESUS RAMON BRITO \r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(217, 'J308296023', '\"INVERSIONES BOHORQUEZ C.A.\" (INVERSIONES BOHORQUEZ C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(218, 'J295598670', 'INVERSIONES CHARCUPLAZA C.A (INVERSIONES CHARCUPLAZA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(219, 'J293779286', 'ROCHA CARS, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(220, 'J301833082', 'VIVERO Y RATAN EL RECREO C.A. (VIVERO Y RATAN EL RECREO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(221, 'J314780301', 'MUNDO DEL PC BARQUISIMETO, C.A (MUNDO DEL PC BARQUISIMETO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(222, 'J307871407', 'EL PAJARO SHOP C.A. (EL PAJARO SHOP C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(223, 'J308336874', 'CENTRO TEXTIL V.M.B, CA (CENTRO TEXTIL V.M.B., C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(224, 'J306939865', 'INVERSION DIGITAL C.A. (INVERSION DIGITAL C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(225, 'V122634600', 'FIRAS HOUMAIDAN HOUMAIDAN', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(226, 'J309053523', 'FRUIT CANDY CA (FRUIT CANDY C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(227, 'J300483797', 'REPRESENTACIONES JADIH C A (REPRESENTACIONES JADIH CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(228, 'J294762689', 'FERREMATERIALES SAN ROQUE, C.A. (FERREMATERIALES SAN ROQUE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(229, 'J296532850', 'DISTRIBUIDORA ROCER C.A (DISTRIBUIDORA ROCER C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(230, 'J313725862', 'SHOCK INVERSIONES, C.A. (SHOCK INVERSIONES, C. A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(231, 'J315535807', 'COPYVARGAS 2006 CA (COPYVARGAS 2006 CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(232, 'J295571631', 'MARYOS MANOS DE LUXE CENTRO DE ESTÉTICA INTEGRAL C.A. (MARYOS MANOS DE LUXE CENTRO DE ESTÉTICA INTEG', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(233, 'V074544130', 'NORIS JOSEFINA HERNANDEZ ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(234, 'J309292722', '\"CALZADOS ZARA, C.A\". (\"CALZADOS ZARA, C.A\".)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(235, 'J301768213', 'FARMACIA CORAZON DE JESUS, S.R.L (FARMACIA CORAZON DE JESUS, S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(236, 'J296659214', 'FINCA HOGAR, C.A. (FINCA HOGAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(237, 'J305373728', 'CENTRO OPTICO SALAS, C.A (CENTRO OPTICO SALAS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(238, 'J303798110', 'DONA SHOP, C.A (DONA SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(239, 'J300256103', 'AUTO ACCESORIOS Y PERIQUITOS DANIEL S.R.L. (AUTO ACCESORIOS Y PERIQUITOS DANIEL S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(240, 'J315291169', 'FERRETERIA SAN MIGUEL 2006, C.A. (FERRETERIA SAN MIGUEL 2006, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(241, 'J308828734', 'HOTEL KATUCA, C.A (HOTEL KATUCA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(242, 'J314797620', 'DISTRIBUIDORA LAS TRES A C.A. (DISTRIBUIDORA LAS TRES A CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(243, 'J314774115', 'COMERCIALIZADORA LAS TRES H C.A. (COMERCIALIZADORA LAS TRES H, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(244, 'J296702683', '\"AUTO REACABADOS GUAYANA ,COMPAÑIA ANONIMA\" (\"AUTO REACABADOS GUAYANA, COMPÑIA ANONIMA\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(245, 'J095077861', 'ALMACEN EL HINDU, C.A. (ALMACEN EL HINDU C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(246, 'J307664827', '\"AUTOREPUESTO ECHEGARAY MOTORS,C.A.\" (AUTO REPUESTOS ECHEGARAY MOTORS, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(247, 'J306964509', 'AUTOREPUESTOS DON RAMON, C.A. (AUTO RESPUESTO DON RAMON C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(248, 'J311959947', '\"AUTOREPUESTOS Y ELECTROAUTO MILA, COMPAÑIA ANONIMA\". (\"AUTOREPUESTOS Y ELECTROAUTO MILA, COMPAÑIA A', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(249, 'J311480650', 'AUTO ACCESORIOS JHON,C.A (AUTO ACCESORIOS JHON,C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(250, 'J305978000', 'AGROVENSER,C.A. (AGROVENSER, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(251, 'J304826613', 'COMERCIAL MI CASA, C.A (COMERCIAL MI CASA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(252, 'J306282440', 'COMERCIAL CONTINENTAL, C.A. (COMERCIAL CONTINENTAL, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(253, 'J294355269', 'CRISTALERIA MONAGA, C.A. (CRISTALERIA MONAGA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(254, 'J306562729', 'CRISTALAUTO UPATA S.R.L (CRISTALAUTO UPATA SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(255, 'J295843640', 'CONFITERIA SUPER GOLOSINA, C.A. (CONFITERIA SUPER GOLOSINA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(256, 'J303219128', 'COMPUTER SHOP CA (COMPUTER SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(257, 'J314082604', '\"CONFECCIONES YUSTIN, C.A\" (CONFECCIONES YUSTIN,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(258, 'J296133468', 'CENTRO DE CONEXIONES EL REY, C.A. (CENTRO DE CONEXIONES EL REY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(259, 'J313944262', 'COMERCIAL SONRISA TAN, C.A (COMERCIAL SONRISA TAN, C.A    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(260, 'J293990475', 'CRIST-CHILDREN, COMPAÑIA ANONIMA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(261, 'J314560220', 'CORPORACION LATINOAMERICANA DEL CAUCHO S.A. (CORPORACION LATINOAMERICANA DEL CAUCHO SA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(262, 'J296694915', 'CRIST-CHILD, C.A., (CRIST-CHILD, C.A.,)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(263, 'J311328416', 'COMPUTADORAS RAM,C.A (COMPUTADORAS RAM C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(264, 'J295036515', 'CRIST CHILDREN CA (CRIST CHILDREN CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(265, 'J312706252', 'CASA FIAT C A (CASA FIAT, CA.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(266, 'J312926333', 'DIGITAL WORLD, C.A., (DIGITAL WORLD, C.A.,)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(267, 'J308513725', 'DISTRIBUIDORA JADIL, C.A. (DISTRIBUIDORA JADIL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(268, 'J294509312', 'EL MUNDO DE LAS GORDITAS CA (EL MUNDO DE LAS GORDITAS CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(269, 'J295537000', 'FARMACIA RASHALINDA C A ( FARMACIA RASHALINDA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(270, 'J309857290', '\"FARMA MUNDO, C.A.\" (FARMA MUNDO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(271, 'J296236623', 'FERREAGRO LA VICTORIA, C.A. (FERREAGRO LA VICTORIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(272, 'J095187772', '\"FERRETERIA DINSA, COMPAÑIA ANONIMA\" (\"FERRETERIA DINSA, COMPAÑIA ANONIMA\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(273, 'J307012315', 'FIESTA CASINOS GUAYANA C.A. (FIESTA CASINOS GUAYANA C.A.   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(274, 'J095191427', 'FERRETERIA ELECTRICA CARONI C A (FERRETERIA ELECTRICA CARONI, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(275, 'J316874478', 'FOTO ESTUDIO ROMA DISEñO E IMPRESIONES C.A (\"FOTO ESTUDIO ROMA DISEÑO E IMPRESIONES C.A\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(276, 'J296779767', '\"FASHION  STYLE YASMIRA C.A\" (\"FASHION  STYLE YASMIRA C.A\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(277, 'J307897686', 'GALEARTE  C.A (GALEARTE C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(278, 'J317091507', 'GLOBAL SYSTEM COMPUTER C.A (GLOBAL SYSTEM COMPUTER C.A    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(279, 'J313120553', 'GRUPO 3H,C.A (GRUPO 3H, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(280, 'J295868847', 'GRUPO ATLANTICO S.A (GRUPO ATLANTICO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(281, 'J316695409', 'GORDYS` PLUS,C.A. (GORDYS´PLUS, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(282, 'J294134025', 'HARDWARE KING, C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(283, 'J300998398', '¨HOTEL TUMEREMO CITY, C.A.¨ (TUMEREMO CITY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(284, 'J295449976', 'INVERSIONES ELECTRONICA ARFA,C.A (INVERSIONES ELECTRONICA ARFA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(285, 'J313416401', 'INVERSIONES PEDRO-JOSE, C.A. (INVERSIONES PEDRO-JOSE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(286, 'J296751935', 'INVERSIONES Y REPRESENTACIONES COMPU MARKETING COMPAÑIA ANONIMA (INVERSIONES Y REPRESENTACIONES COMP', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(287, 'J295675577', 'SYSCOMP DE VENEZUELA, C.A (SYSCOMP DE VENEZUELA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(288, 'J296692475', '\"INVERSIONES Y JOYERIA CENTER,C.A\" (INVERSIONES Y JOYERIA CENTER,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(289, 'J316401928', 'INVERSIONES HEDI, C.A. (INVERSIONES HEDI C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(290, 'J295441568', 'INVERSIONES DOBLE PICA C.A. (INVERSIONES DOBLE PICA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(291, 'J295786409', '\"JOYERIA FESTINA\", C.A. (\"JOYERIA FESTINA\", C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(292, 'J294607039', 'JACK POLO, C.A. (JACK POLO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(293, 'J294568807', 'JOYERIA VICTORIA, C.A. (JOYERIA VICTORIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(294, 'J303532411', 'JOYERIA \"ISIDORA COMPAÑIA ANONIMA\" (JOYERIA  \"ISIDORA COMPAÑIA ANONIMA\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(295, 'J296331111', 'JOYERIA LA FERIA DEL ORO, C.A. (JOYERIA LA FERIA DEL ORO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(296, 'J303412831', 'JOYERIA E INVERSIONES ZULIA, C.A. (JOYERIA E INVERSIONES ZULIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(297, 'J308256170', 'JOYERIA OMEGA C.A (JOYERIA OMEGA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(298, 'J293600421', 'JOYERIA EL AGUILA, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(299, 'J302391814', '\"METAL -MACA GUAYANA, C.A.\" (METAL MACA GUAYANA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(300, 'J313620599', 'MICROEMPRESA LOS DETALLES (MICROEMPRESA \"LOS DETALLES\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(301, 'J312513632', 'MICROEMPRESA INVERSIONES EL BACHIR (MICROEMPRESA \"INVERSIONES EL BACHIR\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(302, 'J295690347', 'MICROEMPRESA \"MILI MOTO\" (MICROEMPRESA \"MILI MOTO\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(303, 'J293979021', 'NOVO AUTO, C.A (SERAGROPEC,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(304, 'J308600270', 'ORO DISEÑOS NUR BELEN, COMPAÑIA ANONIMA. (ORO DISENOS NUR BELEN, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(305, 'J297025618', 'RENÉ ORINOCO, C.A. (RENÉ ORINOCO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(306, 'J314851365', 'REPRESENTACIONES ZAPATA, C.A (REPRESENTACIONES ZAPATA, C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(307, 'J294940226', 'REPRESENTACIONES EL PROGRESO,CA (REPRESENTACIONES EL PROGRESO)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(308, 'J303869416', 'REPRESENTACIONES RAFOMAR II,C.A (REPRESENTACIONES RAFOMAR II,  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(309, 'J313902888', '\"REAL DE MINAS COMPAÑIA ANONIMA\". (\"REAL DE MINAS, COMPAÑIA ANONIMA\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(310, 'J294024440', 'SILPECA CA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(311, 'J305543542', 'SLENDER CENTER GUAYANA C.A. (SLENDER CENTER GUAYANA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(312, 'J312325348', 'SUPERMERCADO CASATODO,C.A (SUPERMERCADO CASATODO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(313, 'J314670743', 'SUMINISTROS COMPUGRAFIC C.A (SUMINISTROS COMPUGRAFIC CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(314, 'J310210128', 'SISTEMAS AM3 CA (SISTEMAS AM3, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(315, 'J302543983', 'MOTORES, C.A. (MOTORES,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(316, 'J312969539', 'SUPERMERCADO EL PERFECTO,C.A (SUPERMERCADO EL PERFECTO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(317, 'J295628200', 'SUPERMERCADO LA HERMOSA C.A (SUPERMERCADO LA HERMOSA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(318, 'J305998019', 'SHOP WAVE, C.A. (SHOP WAVE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(319, 'J295090919', '\"TK TECHNOLOGYS, C.A\" (TK TECHNOLOGYS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(320, 'J296424535', '\"TIRE EXPRESS EL GUAMO C.A\" (\"TIRE EXPRESS EL GUAMO C.A\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(321, 'J302661021', 'TALLER Y JOYERIA EL CORAL, S.R.L. (TALLER Y JOYERIA EL CORAL, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(322, 'J316787699', 'VIVERES PARIA, C.A (VIVERES PARIA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(323, 'J316353346', 'VIVERES LA MINA, C.A (VIVERES LA MINA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(324, 'J295662840', 'WHITE, C,A (WHITE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(325, 'J312025549', 'YINYI, C.A. (YINYI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(326, 'J095147401', 'DISTRIBUIDORA CAMPOS, C.A (\"DISTRIBUIDORA CAMPOS, C.A.\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(327, 'J095169197', 'ABASTOS LOS CAMPOS S R L (ABASTOS LOS CAMPOS, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(328, 'J315958430', 'DISTRIBUIDORA BERMUDEZ-DIALLO, C.A. (DISTRIBUIDORA BERMUDEZ-DIALLO, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(329, 'J294754465', 'TREMENS, C.A (TREMENS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(330, 'V114398612', 'ELVIRA CAROLINA LUGO BELLO  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(331, 'J311169946', 'IMPORTADORA AXCEL 212 C.A. (G)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(332, 'J312041803', 'INVERSIONES Y FRIGORIFICO CAPELINHA, C.A. (INVERSIONES Y FRIGORIFICO CAPELINHA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(333, 'J001668721', 'JOYERIA CLAVEL C.A. (JOYERIA CLAVEL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(334, 'J002241748', 'HOTEL FRANCIA CA (HOTEL FRANCIA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(335, 'J297040790', 'INVERSIONES BARVALENTINA 3.000, C.A. (INVERSIONES BARVALENTINA 3.000, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(336, 'J295411677', 'INVERSIONES CIBER MOVIL C.A. (INVERSIONES CIBER MOVIL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(337, 'J316310620', 'SCRUPLES ALTA PELUQUERIA, C.A. (SCRUPLES ALTA PELUQUERIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(338, 'V157931535', 'CARMEN ZENAIDA DIAZ PARRA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(339, 'J301931165', 'DISTRIBUIDORA DUTY FREE,C.A (DISTRIBUIDORA DUTY FREE,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(340, 'J295451466', '\"PERFUMES PRESTIGIO, C.A.\" (PERFUMES PRESTIGIO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(341, 'J312698470', 'INVERSIONES VIMENVI, C.A. (....)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(342, 'J303822410', 'INVERSIONES PELICANO MAR, C.A (INVERSIONES PELICANO MAR C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(343, 'J316275590', 'AGROCRIA CHILI VELOZ, C.A. (X)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(344, 'V029476108', 'HALIME BAHKOS DE SAAD    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(345, 'J308760820', 'INVERSIONES YUFAANAN, C.A. (INVERSIONES YUFAANAN, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(346, 'J002905239', 'FERRETERIA Y BAZAR MONTEMAR SRL (FERRETERIA Y BAZAR MONTEMAR, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(347, 'J295187297', 'INVERSIONES CREILYS DAYATAIMY,C.A (INVERSIONES CREILYS DAYATAIMY,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(348, 'J295694121', 'HOTEL LA GRAN VENECIA, C.A. (HOTEL LA GRAN VENECIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(349, 'J314246488', 'INVERSIONES DIANA MDI, C.A. (INVERSIONES DIANA MDI, C.A.   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(350, 'J295529953', 'AUTO REPUESTOS GALVIS  C.A. (AUTO REPUESTOS GALVIS  C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(351, 'J305690758', 'BAR RESTAURANT FUA FAI, C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(352, 'J302264529', 'AGENCIA DE LOTERIA CHABELA S.R.L (AGENCIA DE LOTERIAS CHABELA,S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(353, 'J302383790', 'LAVADO ENGRASE Y SERVICIO VENEZUELA C.A. (\"LAVADO, ENGRASE Y SERVICIO VENEZUELA C.A\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(354, 'J309609777', 'DISTRIBUIDORA VERDE-AZUL C.A (DISTRIBUIDORA VERDE-AZUL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(355, 'V135332379', 'MARIA A VALENCIA B ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(356, 'V142835920', 'LORENA CAROLINA CARBONELL BETANCOURT     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(357, 'J316118703', 'DIVA DIVINA, C.A. (0)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(358, 'J295921608', 'INVERSIONES Y SERVICIOS 311, C.A. (INVERSIONES Y SERVICIOS 311)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(359, 'J308894478', 'LICORERIA EL METRO DE CARICUAO C.A. (LICORERIA EL METRO DE CARICUAO)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(360, 'J311500197', 'QUINCALLA Y ZAPATERIA MINI-BAZAR S.R.L. (QUINCALLA Y ZAPATERIA MINI-BAZAR, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(361, 'V062173102', 'SIMONE MILITE ROMANO     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(362, 'J001943943', 'SALON DE BELLEZA MI NOMBRE SRL (SALON DE BELLEZA MI NOMBRE SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(363, 'J300809447', 'INVERSIONES MERRY CHRISTMAS SRL (INVERSIONES MERRY CHRISTMAS SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(364, 'V000211130', 'PEDRO CARRION  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(365, 'J305262900', 'ABASTOS COLOMBIA C.A (F)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(366, 'J305616760', 'DISTRIBUIDORA DONCHIQUI, C.A. (DISTRIBUIDORA DONCHIQUI, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(367, 'J302938694', 'DISTRIBUIDORA REICOLOR C A (DISTRIBUIDORA REICOLOR C A    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(368, 'J308188921', 'PANADERIA Y PASTELERIA LA GRAN CALIFORNIA, C.A (PANADAERIA Y PASTELERIA LA GRAN CALIFORNIA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(369, 'V061654360', 'MARIA DE LOURDES ALBARRACIN RAMOS     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(370, 'J296756406', 'INVERSIONES EL CALOR, C.A. (INVERSIONES EL CALOR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(371, 'J294502776', 'SALON DE BELLEZA FRANCHESKA ESTILOS C.A (SALON DE BELLEZA FRANCHESKA ESTILOS C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(372, 'V068723600', 'LUCAS HERNANDEZ BERNAL   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(373, 'J312626992', 'INVERSIONES DOU DOU SHOP, S.R.L. (INVERSIONES DOU DOU SHOP, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(374, 'V094982240', 'JOSEPH HAYEK SAYEK ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(375, 'E843953720', 'YADIHT YARLEY PARADA GUERRERO\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(376, 'J295228260', 'REPRESENTACIONES WILLY CENTER W.H. C.A. (REPRESENTACIONES WILLY CENTER W.H.C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(377, 'J314177494', 'COMIDAS AL INSTANTE NATURAL C.A (COMIDAS AL INSTANTE NATURAL C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(378, 'J294008119', 'CONSULTORIO OFTALMOLÓGICO POPULAR ALTAMAR C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(379, 'J296628807', 'TASCA RESTAURANT MAKUMBA, C.A. (X)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(380, 'J294727204', 'COMERCIALIZADORA RIO SANA 2027 C.A (COMERCIALIZADORA RIO SANA 2027, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(381, 'J294381707', 'INVERSIONES RAKSON 61 C.A (INVERSIONES RAKSON 61, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(382, 'V062805826', 'AMADORA GOMEZ DE MARIÑO  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(383, 'J312045469', 'INVERSIONES NISI 71, C.A. (INVERSIONES NISI 71, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(384, 'J302740215', 'NATURAL NEZZHEN S.R.L (NATURAL NEZZHEN SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(385, 'V197337717', 'SANDRA Y BARON G \r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(386, 'J305090750', 'PANADERIA Y PASTELERIA PRODIGANA, C.A. (PANADERIA Y PASTELERIA PRODIGANA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(387, 'J315598620', 'CAFE Y RESTAURANT LAZARETO,C.A (CAFE Y RESTAURANT LAZARETO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(388, 'J294074553', 'BAZARES VIC CAR 2007 C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(389, 'J000623805', 'PANADERIA Y PASTELERIA LA CRIOLLA SRL (PANADERIA Y PASTELERIA LA CRIOLLA SR)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(390, 'J306839070', 'GLOBAL COM C.A (GLOBAL COM, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(391, 'J307225980', 'MANSUR SHOP C.A (MANSUR SHOP)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(392, 'J308201936', 'SOLD C.A (SOLD, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(393, 'J300522016', 'ELIASTEX PALACE SHOP CA (ELIASTEX PALACE SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(394, 'J295569289', 'EL REY DEL HOGAR, C.A. (EL REY DEL HOGAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(395, 'J314966588', 'EL ALERTO C.A (EL ALERTO,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(396, 'J313909149', 'VANESSA FLOWERS LIFE, C.A. (VANESSA FLOWERS LIFE,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(397, 'J065097132', 'NABALA IMPORT, C.A. (NABALA IMPORT, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(398, 'J295418337', 'FRANCIA HOGAR, C.A. (FRANCIA HOGAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(399, 'J316618900', 'BURGOS 5, C.A. (U.E. JULIAN VISO, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(400, 'J313892572', 'CHOCOTITOS MARKET I C.A. (CHOCOTITOS MARKET I)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(401, 'J310558973', 'ELECTRONICA JOYAS DEL CARIBE, C.A. (ELECTRONICA JOYAS DEL CARIBE)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(402, 'J302514355', 'AZUCAR SPORT C.A (AZUCAR SPORT)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(403, 'E822786840', 'LISHA WU    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(404, 'J308540943', 'BATTISTA CIMAGLIA DE DONATO ANTONIO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00');
INSERT INTO `sisg_finalsclients` (`id`, `rif`, `description`, `name`, `lastName`, `phone`, `email`, `fiscalAddress`, `enable`, `creation_date`) VALUES
(405, 'V081103484', 'ALEJANDRO CONTRERAS ARAQUE  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(406, 'V105610463', 'CARMELA AMIRANTE DE TORRES  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(407, 'J309887998', 'LA DOÑA DEL LLANO REPOSTERIA CAFE C.A (LA DOÑA DEL LLANO REPOSTERIA CAFÉ, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(408, 'V039147722', 'JOSE ELPIDIO VASQUEZ     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(409, 'V161263946', 'CARLOS JOSE CUADROS GARCIA  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(410, 'J090356746', 'LICORERIA RON Y ALEGRIA, S.A. (LICORERIA RON Y ALEGRIA, S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(411, 'J304734000', 'SALVADOR, C.A. (SALVADOR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(412, 'V024790866', 'JUANA DEL CARMEN ORTEGA  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(413, 'J307398205', 'ZAPATERIA MI BOTA C.A. (ZAPATERIA MI BOTA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(414, 'J304427360', 'RETOÑITOS, C.A. (RETOÑITOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(415, 'J303850790', 'MERCADITO ALTO BARINAS C.A (MERCADITO ALTO BARINAS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(416, 'J305187207', 'FABRICA D CALZADOS ZAPIVER C.A. (.,...)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(417, 'J316482499', 'BRYGA 325748 C.A. (BRYGA 325748 C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(418, 'J306961550', 'INVERSIONES MARIA 789, SRL (INVERSIONES MARIA 789, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(419, 'J301167058', 'PIZZERIA Y RESTAURANT PIE GRANDE C A (PIZZERIA RESTAURANT PIE GRANDE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(420, 'J308568767', 'DISTRIBUIDORA DIAZ, C.A (DISTRIBUIDORA DIAZ, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(421, 'J001353852', 'ESTACIONAMIENTO PEREZ Y BAEZ, C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(422, 'J002367156', 'ESTACIONAMIENTO BRESO, S.R.L. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(423, 'J303315135', 'PANADERIA Y PASTELERIA LA ORQUIEDEA, C.A (PANADERIA Y PASTELERIA LA ORQUIDEA, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(424, 'J294860672', 'INVERSIONES LIZ  IRAN C.A. (X)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(425, 'J315103893', 'ANIME Z VALERY CA (ANIME Z VALERY CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(426, 'J001789006', 'INVERSIONES HIPOCAMPO -HIPO, CA (A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(427, 'J002105720', 'SUPERMERCADO OLTRE MARE C A (X)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(428, 'V012218490', 'CARMEN PARRA DE PEREZ    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(429, 'J316772802', 'INVERSIONES NETEKIL, C.A. (,,,,,,)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(430, 'V106319797', 'JAIME ALBERTO BLANCO MEDINA ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(431, 'J308459119', 'LA PERFEZIONE C.A (LA PERFEZIONE C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(432, 'J002157399', 'DEPORTES CASTELO DOS, S.R.L. (DEPORTES CASTELO DOS, S.R.L. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(433, 'J080255143', 'PLASTICOS COLASACCO C A (PLASCOCA    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(434, 'J307718994', 'REPUESTOS KARIMAR C A (REPUESTOS KARIMAR C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(435, 'J309765191', 'REPUESTOS TERE C A (REPUESTOS TERE C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(436, 'J306909761', 'COMERCIALIZADORA EXCLUSIVA DE ORIENTE C A (COMERCIALIZADORA EXCLUSIVA DE ORIENTE C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(437, 'J312827033', 'DISTRIBUIDORA JEANKO C A (DISTRIBUIDORA JEANKO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(438, 'J316156060', 'CASA DE REPUESTOS LA COSTA C.A. (CASA DE REPUESTOS LA COSTA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(439, 'J310923310', 'ATLANTIC FOODS  DELICATESSES, C.A. (ATLANTIC FOODS  DELICATESSES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(440, 'J313661945', 'M.G.M. COMUNICACIONES C A (M.G.M. COMUNICACIONES C A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(441, 'J080154037', 'TALLER Y REPUESTOS ATLANTICO C A (TALLER Y REPUESTOS ATLANTICO C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(442, 'J295366035', 'MULTISERVICIOS LA SOLUCION AH 2008, C.A. (MULTISERVICIOS LA SOLUCION AH 2008, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(443, 'V044981153', 'ODEALDO GONZALEZ \r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(444, 'J310313059', 'CONNECTING PEOPLE, S.A (CONNECTING PEOPLE, S.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(445, 'J310661251', 'CORPORACION KUMA C A (CORPORACION KUMA,CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(446, 'J296479828', 'AUTO PARTES GARCIA C A (AUTO PARTES GARCIA C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(447, 'J309681036', 'TECNICA DEL CAUCHO JESUS C A (TECNICA DEL CAUCHO JESUS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(448, 'J303588948', 'AUTO SERVICIOS EL FRIO SA (AUTO SERVICIOS EL FRIO, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(449, 'J316721914', 'LA CASA DEL KIT C A (LA CASA DEL KIT C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(450, 'J311845534', 'SU PINTURA C A (SU PINTURA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(451, 'J308523275', '\"SERVICIOS MULTIPLES MONCHO\" C A (SERVICIOS MULTIPLES MONCHO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(452, 'J306530126', 'MULTISERVICIOS LAR C.A. (ENTONACION DE MOTORES LUIS)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(453, 'J080140702', 'ELECTRO AUTO REGULO C A (AGROPECUARIA ROMERO GOMEZ CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(454, 'J309843362', 'ALFA CAR CENTER C A (ALFA CAR CENTER, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(455, 'J296000654', 'UNIWELL ZONA ORIENTE C A (UNIWELL ZONA ORIENTE C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(456, 'J301963180', 'INVERSIONES Y MANTENIMIENTOS FERRO-K,C.A. (INVERSIONES Y MANTENIMIENTOS FERRO-K)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(457, 'J306907769', 'COMERCIALIZADORA IRMA, C. A. (COMERCIALIZADORA IRMA,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(458, 'J315105110', '\"COMERCIAL SEÑOR PEPE C A\" (COMERCIAL SEÑOR PEPE C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(459, 'J296533164', 'TALLER INSTAGAS ARAGUA,  C.A. (TALLER INSTAGAS ARAGUA,  C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(460, 'J309671340', 'LA CASA DEL TAXISTA KOREANO  C A (LA CASA DEL TAXISTA KOREANO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(461, 'J310599181', 'FREN AUTO MILENIUM C A (COOPERATIVA DE TRANSPORTE EXCEL. R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(462, 'J295589352', 'WILLIAM EL OFERTON CA (WILLIAM EL OFERTON CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(463, 'J295134495', 'FERREPINTURAS LOS CUMANAGOTOS C A (FERREPINTURAS LOS CUMANAGOSOTOS, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(464, 'J315820897', 'CHEA S STYLE C A (CHEA S STYLE CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(465, 'J315466660', 'LAMAS PHONE C A (LAMAS PHONE CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(466, 'J312635967', 'AUTO PART EL CUMANES C A (AUTO PART EL CUMANES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(467, 'V139360776', 'ISABEL MARIA LOPEZ ALFARO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(468, 'J296643776', 'LA ZONA 4X4 C A (LA ZONA 4X4 C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(469, 'J309527924', 'SKALA C A (SKALA C A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(470, 'J297025685', 'FERRETERIA FARIAS SIGLO XXI CA (FERRETERIA FARIAS SIGLO XXI CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(471, 'J305891141', 'FARMACIA EL ROSAL C A (FARMACIA EL ROSAL C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(472, 'V119034007', 'GLORYS JOSE MARCANO DE CICCIARELLA    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(473, 'J313219797', 'REPUESTOS ATLANTIC C A (REPUESTOS ATLANTIC C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(474, 'J080064500', 'FARMACIA MERIDA, C A (FARMACIA MERIDA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(475, 'J316241033', 'EL ANGEL DEL REPUESTO C A (EL ANGEL DEL REPUESTO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(476, 'J297050124', 'GRUPO DON SIMON CA (GRUPO DON SIMON CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(477, 'J307254149', 'BICI SERVI ORIENTE C A (BICI SERVI ORIENTE C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(478, 'J315370174', 'CAJETINES FRENOS Y SERVICIOS CEDEÑO,CA (CAJETINES FRENOS Y SERVICIOS CEDEÑO C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(479, 'J308254908', 'TELEFONICA ORIENTAL S A (TELEFONICA ORIENTAL,S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(480, 'J293797136', 'AUTOMOTRIZ SAMA C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(481, 'J311005285', 'REPUESTOS Y ACCESORIOS EL ZULIANO C A (REPUESTOS Y ACCESORIOS EL ZULIANO C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(482, 'J314017411', 'TELPHONE JM C A (TELPHONE JM CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(483, 'J306665757', 'COMERCIAL LA GRIFERIA, SRL (COMERCIAL LA GRIFERIA S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(484, 'J080285131', 'JOMAGA, C.A. (JOMAGA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(485, 'J080235517', 'OPTICA ROSS C A (OPTICA ROSS C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(486, 'J309357433', 'MERIENDITAS Y ALGO MAS C A (MERIENDITAS Y ALGO MAS C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(487, 'J295691572', 'MATERIALES HERSAN,C.A (MATERIALES HERSAN,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(488, 'J315868784', 'MIS PELITOS C A (MIS PELITOS C A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(489, 'J315890615', 'SUPPLY JEEP C A (SUPPLY JEEP C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(490, 'J308173223', 'FARMACIA Q-MANAGOTO XXI C A (FARMACIA Q-MANAGOTO XXI C A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(491, 'J295414897', 'PINTACRILICO, CA (PINTACRILICO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(492, 'J316465209', 'INVERSIONES SUMI ORIENTE C A (INVERSIONES SUMI ORIENTE C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(493, 'V177332786', 'MARIA FERNANDA PEREZ CABELLO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(494, 'J307403233', 'PAPELERIA Y VARIEDADES MULTIAHORRO C A (PAPELERIA Y VARIEDADES MULTIAHORRO C A    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(495, 'J294695043', 'CIBER CAFE UPATA C A (CIBER CAFE UPATA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(496, 'J296280924', 'INVERSIONES DIVINE FRUITS ORIENTE, C.A (INVERSIONES DIVINE FRUITS ORIENTE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(497, 'J294384919', 'MATERIALES DON CHEVO C A (MATERIALES DON CHEVO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(498, 'J306226435', 'DIAGNOSTICO Y SERVICIO AUTOMOTRIZ  C A (DIAGNOSTICO Y SERVICIO AUTOMOTRIZ C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(499, 'J316345173', 'FRENOS GABINO C A (FRENOS GABINO C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(500, 'J316315967', 'COMUNICACIONES 416 PLAZA MAYOR C A (COMUNICACIONES 416 PLAZA MAYOR C A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(501, 'J296271046', 'INFODIARIO CA (INFODIARIO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(502, 'J316712290', 'GRUPO BELFA C.A (GRUPO BELFA C.A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(503, 'J296463441', 'OCASO,C.A. (OCASO,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(504, 'J313955043', 'DIGI CELULAR C.A. (DIGI CELULAR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(505, 'J308824216', 'MULTI OFERTAS DELTA 2005 C A (MULTI OFERTAS DELTA 2005 C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(506, 'J080092007', 'LICORERIA LA PORTE$A C A (LICORERIA LA PORTEÑA, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(507, 'J294356940', 'FLORISTERIA ESTRELLA DE BELEN, C.A. (FLORISTERIA ESTRELLA DE BELEN, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(508, 'J296361401', 'SUCCESS SHOP AC SA (SUCCESS SHOP AC SA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(509, 'J297106308', 'MASCOTAS REGINA XXI C A (MASCOTAS REGINA XXI C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(510, 'J296295891', 'AGS INVERSIONES,C.A (AGS INVERSIONES,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(511, 'V136484768', 'ANA  LUCIA MARTINEZ PLAZAS  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(512, 'V037646632', 'NORA MARINA TELLES ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(513, 'J304407009', 'PRODUCTOS GENERICOS DE LIMPIEZA SIN ENVASE CARRERO C.A (PRODUCTOS GENERICOS DE LIMPIEZA SIN ENVASE C', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(514, 'J305035016', 'SALA ANDINA CA (SALA ANDINA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(515, 'J090388532', 'SERVICIOS AGROPECUARIAS JAJI, CA (SERVICIOS AGROPECUARIAS JAJI, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(516, 'J293830699', 'ZONA EXCLUSIVA C.A (ZONA EXCLUSIVA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(517, 'J307828889', 'REPUESTOS SANTA CRUZ CA (REPUESTOS SANTA CRUZ CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(518, 'J304503962', 'FARMACIA SANTA ELENA S.A. (FARMACIA SANTA ELENA S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(519, 'J310264902', 'PIZZA PIAZZA C A (PIZZA  PIAZZA  CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(520, 'J295474326', 'INVERSIONES LUCEDI  DAC,C.A (INVERSIONES LUCEDI  DAC,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(521, 'E005322092', 'VICENZO PIACQUAIDIO GUGLIEMUCCI\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(522, 'J302272467', '\"BAR RESTAURANT PUERTO LIBRE, S.R.L.\" (\"BAR RESTAURAN PUERTO LIBRE, S.R.L\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(523, 'J295481250', 'FOTO EXPRESS,C.A (FOTO EXPRESS,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(524, 'V159558726', 'LEIDY DIANA FARFAN GARCIA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(525, 'J304883030', '\"INVERSIONES LEYDI, C.A.\" (\"INVERSIONES LEYDI, C.A.\"   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(526, 'J315976242', 'PA DONDE LOS MUCHACHOS, C.A. (PA DONDE LOS MUCHACHOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(527, 'J065052457', 'EL BODEGON ITALIANO, C.A. (BODEGON ITALIANO, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(528, 'J301094158', 'LA MARINA IMPORT, C.A. (LA MARINA IMPORT, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(529, 'J294726356', 'FINISH LINE, C.A (FINISH LINE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(530, 'J294284426', 'REPUESTOS  LAGUNA, C.A. (REPUESTOS LAGUNA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(531, 'J295689187', 'AUTOLAVADO FORMULA 1, C.A (AUTOLAVADO FORMULA 1,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(532, 'J311299521', 'LA FERIA SHOES STORE,C.A (LA FERIA SHOES STORE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(533, 'J296773785', 'BAMBOO SHOP, C.A. (BAMBOO SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(534, 'J296183180', 'ARRECIFE, C.A. (ARRECIFE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(535, 'V138487080', 'REFAAT ILBEH OULBEH', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(536, 'J316348865', 'FRANLIST. COM C.A (FRANLIST. COM C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(537, 'J307829737', 'UNISEX INTERNACIONAL C.A (UNISEX INTERNACIONAL,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(538, 'J311814590', 'CORNER STORE C.A. (CORNER STORE C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(539, 'J065031727', 'CASTOR INTERNACIONAL C A (CASTOR INTERNACIONAL,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(540, 'V132820828', 'EIMAN EL YARAMANI FAHED  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(541, 'J313430129', 'REPRESENTACIONES ALTAGRACIA S.A (REPRESENTACIONES ALTAGARCIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(542, 'V135650478', 'YELITZA JOSEFINA (MOVIL - GAMES Y.J.O.M., F.P.) ORDAZ MILLAN  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(543, 'J310916756', 'MARGARITA STAR PC C.A. (MARGARITA STAR PC C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(544, 'J065036648', 'TECNI ALINEACION EL ESPINAL S.R.L. (TECNI ALINEACION EL ESPINAL S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(545, 'E843110536', 'CRISTIAN ROLANDO BARROSO ARAQUE\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(546, 'J308233307', 'HIELO SAN JOSE C.A (HIELO SAN JOSE)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(547, 'J296988269', 'USCOMPUTER, C.A (USCOMPUTER,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(548, 'J065110384', 'SHOE CENTER C.A. (SHOE CENTER, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(549, 'J310179069', 'INVERSIONES LAS 5A, C.A (INVERSIONES LAS 5 A, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(550, 'J300715531', 'FARMACIA PARAGUACHI C A (FARMACIA PARAGUACHI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(551, 'J293752990', 'DAYRE SHOP, C.A. (DAYRE SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(552, 'J309785001', 'GORCRIS JEANS C.A. (GORCRIS JEANS)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(553, 'J309772163', 'XTREMO CAFE, C.A. (XTREMO CAFÈ)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(554, 'J312482540', 'INVERSIONES PIRMAR, C.A (INVERSIONES PIRMAR C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(555, 'J309492535', 'ANDI SHOP, C.A. (ANDI SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(556, 'J293907950', 'MG FASHION CAFE, C.A. (MG FASHION, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(557, 'J296487260', 'EL MUNDO DEL AMORTIGUADOR MARGARITA, C.A. (EL MUNDO DEL AMORTIGUADOR MARGARITA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(558, 'V040480451', 'EMILIO RODRIGUEZ MILLAN  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(559, 'J294087191', 'GEMA GROUP, C.A (GEMA GROUP, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(560, 'V094254180', 'DANIEL JOSE MORENO SALAZAR  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(561, 'V083843930', 'SABINA DEL CARMEN MARIN  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(562, 'V048866120', 'LUISA ELENA GIL \r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(563, 'J305853061', 'LICORERIA EL CORRECAMINOS GEORGE, C.A. (LICORERIA EL CORRE CAMINO GEORGE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(564, 'J314999770', 'YAQUE MARE, C.A. (YAQUE MARE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(565, 'J295476272', '\"PA´DANIEL CARS\". C.A (\"PA´DANIEL CARS\". C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(566, 'J296316252', 'RAJI STORE, C.A. (RAJI STORE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(567, 'J315150727', 'INVERSIONES Y DISTRIBUCIONES ROJAS, C.A. (INVERSIONES Y DISTRIBUCIONES ROJAS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(568, 'J303828116', 'RESTAURANT LA CRIOLLADA C.A (RESTAURANT LA CRIOLLADA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(569, 'J313139378', 'DISTRIBUIDORA A.B.P 2005 C.A (DISTRIBUIDORA A.B.P., 2005, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(570, 'J312022647', 'LENCERIA DAMASCO, C.A. (LENCERIA DAMASCO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(571, 'J303828205', 'INVERSIONES RAMON MARIN C.A (URBANISMOS Y MOVIMIENTOS CARABOB, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(572, 'J304922680', 'AGENCIA DE FESTEJOS LAS AMERICAS C.A (AGENCIA DE FESTEJO LAS AMERICAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(573, 'V080957790', 'ARVEL ARNALDO GUERRA DAZA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(574, 'J305753458', 'ESTUDIO ESTETICO UNISEX ENMANUEL, C.A. (ESTUDIO ESTETICO UNISEX ENMANUEL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(575, 'J313650846', '\"VIDEOXPLODE C.A.\" (\"VIDEOXPLODE C.A.\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(576, 'J312902892', 'RESTAURANT EL FRITIN, C.A. (RESTAURANT EL FRITIN C,A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(577, 'J312309156', 'SABRIN IMPORT, C.A. (SABRIN IMPORT, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(578, 'J295631880', 'EL MAGNIFICO KIDS,  C.A. (EL MAGNIFICO KIDS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(579, 'J301998065', 'CENTRAL SPORT TOURS, C.A. (CENTRAL SPORT TOURS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(580, 'J307485930', 'HADI SHOP, C.A. (HADI SHOP, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:00:00'),
(581, 'V169314612', 'KINAN NASER (NASER IMPORT, F.P) EL CHAER NASR   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(582, 'J311189645', 'PANADERIA Y PASTELERIA RIO DE ORO, C.A. (PANADERIA Y PASTELERIA RIO DE ORO,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(583, 'J305811083', 'FESTEJOS Y LICORERIA THE FAT, C.A. (FESTEJOS Y LIC THE FAT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(584, 'J307548886', 'BODEGON THE FAT II C.A (BODEGON THE FAT II)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(585, 'J309266519', 'CENTRO DE COPIADO Y REPRODUCCION ACARAURE,C.A (CENTRO DE COPIADO Y REPRODUCCION ACARAURE,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(586, 'J085240349', 'FARMACIA METROPOLITANA,C.A (FARMACIA METROPOLITANA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(587, 'V021542616', 'PEDRO EDILIO ANTONIO TORRES ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(588, 'J304038623', 'FARMA MERCADO, C.A. (FARMA MERCADO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(589, 'J302906342', 'FARMACIA GIRASOL CA (FARMACIA GIRASOL CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(590, 'J300605280', 'REPUESTOS LUIS C A (REPUESTOS LUIS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(591, 'J001260218', 'TIERRA AZUL ARTE POPULAR S R L (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(592, 'J309057294', 'CICLO DIGITAL, C.A (CICLO DIGITAL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(593, 'J305357293', 'MELUCIA C.A (MELUCIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(594, 'J295152655', 'COMERCIALIZADORA ARANZZA C.A (COMERCIALIZADORA ARANZZA C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(595, 'J311455272', 'CASA GUARNIERI VENEZUELA, C.A (CASA GUARINIERI VENEZUELA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(596, 'J002653019', 'AREPERA AMADANI, S.R.L (AREPERA AMADANI, S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(597, 'J310975477', 'INVERSIONES EL GRAN GUAITA C.A (INVERSIONES EL GRAN GUAITA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(598, 'J296900124', 'REPRESENTACIONES MIZAMEX 9802,C.A (REPRESENTACIONES MIZAMEX)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(599, 'J295332971', 'TIB-TRI INVERSIONES, C.A (TIB-TRI INVERSIONES, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(600, 'J310369968', 'TIENDA NATURISTA ARTEMISA ABAA, C.A (TIENDA NATURISTA ARTEMISA ABAA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(601, 'J001953787', 'MULTISERVICIOS BATALLON, C.A (MULTISERVICIOS BATALLON, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(602, 'J310069492', 'GIMNASIO MUSCLES PERFECT S.R.L. (GIMNASIO MUSCLES PERFECT SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(603, 'J305062242', 'C.A MIUR (C.A MIUR)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(604, 'J001885994', 'FERRETERIA Y QUINCALLERIA MARACAY, S.R.L. (FERRETERIA Y QUINCALLERIA MARACAY, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(605, 'J296875561', 'SASA ELECTRONIC, C.A. (SASA ELECTRONIC, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(606, 'J293723604', 'DESARROLLOS ENSOGADO, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(607, 'J311547126', 'S.N.C RODRIGUEZ Y MOREJON (S.N.C RODRIGUEZ Y MOREJON)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(608, 'J313141950', 'CREACIONES KINERET 18, C.A. (CREACIONES KINERET 18, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(609, 'J307986298', 'M.E. ESTETIC SALUD, C.A (M.E. ESTETIC SALUD C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(610, 'J295048360', 'DISEÑOS DADA, C.A. (DISEÑOS DADA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(611, 'J304879040', 'SANRIO SURPRISE, C.A (SANRIO SURPRISE,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(612, 'J300836754', 'ALTA PELUQUERIA UNISEX ANI DANNY C A (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(613, 'J003158410', 'CREACIONES LEARSI C.A. (CREACIONES LEARSI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(614, 'J304548656', 'CREACIONES COMPONIX SAMBIL, C.A. (CREACIONES COMPONIX SAMBIL, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(615, 'J306215859', 'CREACIONES COMPONIX SANTA FE,C.A. (CREACIONES COMPONIX SANTA FE)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(616, 'J306771433', 'INVERSIONES COMCO  BOLEITA 18 B CA (INVERSIONES COMCO BOLEITA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(617, 'J303516378', 'CREACIONES FABI 164, C.A. (CREACIONES FABI 164, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(618, 'J309761242', 'CHURROS CHURRIKISIMO, C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(619, 'J308252816', 'COMERCIAL CARRUSEL 2001 C.A (COMERCIAL CARRUSEL 2001 C.A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(620, 'J001347828', 'BAR FUENTE DE SODA BABY BLUE CA (BAR RESTAURANT FUENTE DE SODA BABY BLUE CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(621, 'J312735660', 'OPTICA EN-FOCO, C.A. (OPTICA EN FOCO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(622, 'J002542390', 'INVERSIONES GUILENIA C A (X)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(623, 'J309065289', 'TERRAZA CASTELLANA CA (TERRAZA CASTALLENA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(624, 'J311273824', 'INTIMIDADES CENTER, C.A. (INTIMIDADES CENTER C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(625, 'J310529442', 'CREACIONES EMEBE C.A. (CREACIONES EMEBE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(626, 'J001854835', 'CAUCHOS EL PARAISO C A (NM)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(627, 'J304016735', 'REPUESTOS EL RODEO, C.A. (REPUESTOS EL RODEO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(628, 'J308746177', 'CARNICERIA Y CHARCUTERIA EL LINO C.A. (STATE OF MINNESOTA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(629, 'J302893313', 'ROMANTICA Y COQUETA BOUTIQUE P.O.A, C.A. (ROMANTICA Y COQUETA BOUTIQUE P.O.A., C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(630, 'J305631883', 'REPRESENTACIONES EMBI CORNER C.A (REPRESENTACIONES EMBI CORNER C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(631, 'J295294751', 'INVERSIONES EGO 3000, C.A. (EGO MATERNO CASUAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(632, 'J308827770', 'INVERSIONES PUCARAY 44, C.A (INVERSIONES PUCARAY 44, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(633, 'J000449082', 'FARMACIA EL VELODROMO C.A (FARMACIA EL VELODROMO C.A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(634, 'J000995036', 'FERRETERIA EL CHAMACO, S.A. (FERRETERIA EL CHAMACO, S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(635, 'J310385645', 'FUERZA MOTRIZ 2021, C.A. (FUERZA MOTRIZ 2021, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(636, 'J000658889', 'KORDA MODAS BARALT C.A. (KORDA MODAS BARALT C A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(637, 'J311067019', 'DIRAMIDE, C.A. (DIRAMIDE C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(638, 'V068209826', 'LEOPOLDO PESTANA SERRAO  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(639, 'J300473732', 'MEGA CAUCHOS C A (MEGA CAUCHOS)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(640, 'J309062425', 'FLORISTERIA EL DETALLE, S.R.L. (FLORISTERIA EL DETALLE, S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(641, 'J310281572', 'HELADERIA LA 42 C.A. (HELADERIA LA 42, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(642, 'J294056369', 'INVERSIONES 10336,C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(643, 'J295146159', 'INVERSIONES N G 29-05-74 C.A. (INVERSIONES N G 29-05-74 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(644, 'J309341626', 'REPRESENTACIONES LA ESQUINA CURIOSA, C.A. (REPRESENTACIONES LA ESQUINA CURIOSA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(645, 'J294755801', 'INVERSIONES LA BARREIRA XXI C.A. (INVERSIONES LA BARREIRA XXI C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(646, 'J308655244', 'LAVADOS REPUESTOS Y ACCESORIOS LCJ, C.A. (XXX)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(647, 'J301677528', 'MATERIALES BRION M.B CA (MATERIALES BRION)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(648, 'J001991778', 'DEPORTES CANAIMA C.A (DEPORTES CANAIMA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(649, 'J309417991', 'ACCESORIOS V O E C.A. ( V O E )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(650, 'J316607828', 'FAI-DA-TE MODA, C.A. (FAI-DATE MODA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(651, 'J314237683', 'CORPORACION F-32 COMPAñIA ANONIMA (CORPORACION F-32, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(652, 'J313721883', 'CORPORACION PBJ-180, C.A. (CORPORACION PBJ-180, C.A.     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(653, 'J316471250', 'REPRESENTACIONES A-55 C.A (REPRESENTACIONES A-55 C.A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(654, 'J310578524', 'CORPORACION PB-19, C.A. (CORPORACION PB-19, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(655, 'J308059986', 'CORPORACION X.T 46 C.A (CORPORACION X.T 46)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(656, 'J313612570', 'INVERSIONES GANGSTER 2020 C.A (INVERSIONES GANGSTER 2020 C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(657, 'J315567016', 'CORPORACION C-117 C.A (CORPORACION C-117 C.A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(658, 'J314622013', 'CORPORACION FC-2007, C.A (CORPORACION FC 2007, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(659, 'J294102808', 'LUBRICANTE LULU 1503 C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(660, 'J294056628', 'CORPORACION NIVEL UNO 69, C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(661, 'J294787800', 'CORPORACION L-186;C.A (CORPORACION L-186;C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(662, 'J297048065', 'L.C.P. ALIMENTOS C.A. (L.C.P. ALIMENTOS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(663, 'J307715189', 'FARMACIA NUEVA CIENCIA C.A. (FARMACIA NUEVA CIENCIA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(664, 'J090381066', 'GUSTAVOS EL ESTILO C.A (GUSTAVOS EL ESTILO, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(665, 'J316329372', '\"SPACIO RELAX, C.A\" (\"SPACIO RELAX, C.A\"     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(666, 'J316026876', 'TECHNO STORE C.A (X)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(667, 'J313574597', 'ATELIER DE ORO ATHENA, C.A (ATELIER DE ORO ATHENA, C.A    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(668, 'J300264424', 'ORGANIZACION MGII C.A (ORGANIZACION MGII C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(669, 'J316572633', 'SISTEMA PROFESIONAL DE BELLEZA 2235 C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(670, 'J294114776', '\"ELIZABETH STILUS, C.A.\" (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(671, 'J309961233', 'BORDADOS MYLUJO C.A. (BORDADOS MYLUJO C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(672, 'J312832185', 'ZULUJO FOTO-DVD C.A (ZULUJO FOTO-DVD C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(673, 'J300168310', 'DISTRIBUIDORA LA SELECTA C A (DISTRIBUIDORA LA SELECTA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(674, 'J308049280', 'REPUESTOS GROSS,C.A. (REPUESTOS GROSS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(675, 'J307309814', 'COMPONENTES ELECTRONICOS R.G., C.A. (COMPONENTES ELECTRONICOS R.G., C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(676, 'G200000589', 'INSTITUTO AUTON. CIRCULO DE LA FUERZA ARMADA (NO INDICA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(677, 'V073230574', 'IVAN PASTOR ARRIECHE     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(678, 'J312140100', 'FERRETORNILLOS JUAN CANELON CA (FERRETORNILLOS JUAN CANELON CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(679, 'J310939870', 'DISTRIBUIDORA MARA II, C.A. (DISTRIBUIDORA MARA II, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(680, 'J308029882', 'COMERCIAL SUARCOL C.A (COMERCIAL SUARCOL   C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(681, 'J312620439', 'CORPORACION DIMADA CA (CORPORACION DIMADA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(682, 'J295265913', 'LAKUBO C.A. (LAKUBO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(683, 'J306128115', 'CHERANGY CA (CHERANGY CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(684, 'J303262090', 'VARIEDADES FRANDY C.A (\"VARIEDADES FRANDY COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(685, 'J314886860', 'INVERSIONES MODA JEAN, S.R.L. (INVERSIONES MODA JEANS S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(686, 'J302874785', 'AUTO ROMY C A (AUTO ROMY C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(687, 'J295689888', 'INVERSIONES NIKY 2008, C.A (INVERSIONES NIKY 2008, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(688, 'J307267470', 'LENNIUM SPORT, C.A. (LENNIUM SPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(689, 'J075308204', 'CAUCHOS PILIO S R L (CAUCHOS PILIO S R L     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(690, 'V072188078', 'JUAN CARLOS SEOANE PEREZ ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(691, 'V072121410', 'ANTONIO NICOLAS MOLINA VALERA\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(692, 'J309150405', 'WAITA, C.A. (WAITA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(693, 'J316286290', 'MAIPO, C.A. (MAIPO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(694, 'J316486974', 'TOPACIO,C.A. (TOPACIO,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(695, 'J313142131', 'COMERCIALIZADORA M. D. 11, C.A. (COMERCIALIZADORA M.D. 11 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(696, 'V108582355', 'EUHLENA MARIA ESCUDERO TREJO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(697, 'V139708314', 'MILTON U GOMEZ C \r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(698, 'J075548027', 'H.R. SERVICE, C.A. (H.R. SERVICE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(699, 'J295692510', 'VENTIVAL, C.A. (VENTIVAL,C.QA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(700, 'J308626449', 'INVERSIONES KRAMER, C.A. (INVERSIONES KRAMER, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(701, 'J296912394', 'INVERSIONES FDL, C.A. (INVERSIONES FDL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(702, 'J311326472', 'GRICOPLOM,C.A. (GRICOPLOM,C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(703, 'J003170607', 'INVERSIONES HERMANOS LIN CA (INVERSIONES HERMANOS LIN, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(704, 'J316537897', 'VARIEDADES CHELA 18, C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(705, 'J301461150', 'CASA MILAN CA (CASA MILAN CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(706, 'J316809358', 'FULL CAJITAS STORE, C.A. (X)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(707, 'J304016948', 'POLLOS A-1, C A (POLLOS A-1, C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(708, 'J312082445', 'SUPERMERCADO A-1 C.A. (SUPERMERCADO A-1 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(709, 'J306363637', 'SUPER POLLOS A-1 CA (SUPER POLLOS A-1 CA     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(710, 'J296758590', 'SHAMPOO STUDIO,  C.A. (SHAMPOO STUDIO,  C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(711, 'J294179770', 'COMERCIALIZADORA VIVA 2030, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(712, 'V047978129', 'OTTO LUIS GOMEZ \r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(713, 'V114284943', 'NANCY MARIA (TIENDAS VIVA-COLMENAREZ, F.P.) COLMENAREZ COLMENAREZ\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(715, 'J316597598', 'SUPER TIENDA LATINO MARACAIBO,C.A. (AASDSD)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(716, 'J296243719', 'SUPER TIENDA LATINO COROMOTO C.A (SUPER TIENDA LATINA COROMO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(717, 'J294012400', 'COMERCIAL \"HIELO NARDEMAI \" C.A. (COMERCIAL HIELO NARDEMAI C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(718, 'E822638441', 'LIQIN WU    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(719, 'J295896204', 'PANIFICADORA LOS COCALES CA (PANIFICADORA LOS COCALES,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(720, 'J306491767', 'BAR RESTAURANT HO KOW, C A (BAR RESTAURANT HO KOW, C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(721, 'J315182122', 'INVERSIONES MIRVICAR C A (INVERSIONES MIRVICAR C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(722, 'J308366552', 'INVERSIONES PERICOCAL C A (INVERSIONES PERICOCAL CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(723, 'J308827800', 'BODEGON REÑACA CA (BODEGON REÑACA C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(724, 'V019841010', 'CLARA RAFAELA BARRIOS DE MINEO\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(725, 'V242285693', 'MOHAMAD AL REFAI AL REFAI', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(726, 'V084778890', 'ADOLFO INGENITO CRISI    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(727, 'J296906530', 'LA CASA DE LA PLATA C.A (LA CASA DE LA PLATA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(728, 'J312806443', 'BAR RESTAURANT LA CERTERA C A (BAR RESTAURANT LA CERTERA ,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(729, 'V065538420', 'JOSE ANTONIO RODRIGUEZ   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(730, 'J308692247', 'BAR RESTAURANT YU LONG TOU TIGRE 2001 C A (BAR RESTAURANT YU LONG TOU TIGRE 2001 C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(731, 'J317032543', '\"COMERCIAL BARATISIMO C A\" (COMERCIAL BARATISIMO C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(732, 'J305890463', 'BAR RESTAURANT YU LONG TOU C A (BAR RESTAURANT YU LONG TOU C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(733, 'J310275793', '\"PANADERIA Y PASTELERIA LATINOAMERICANA C A\" (\"PANADERIA Y PASTELERIA LATINOAMERICANA C A\"    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(734, 'J297038701', 'MODAS CARACOL, CA (MODAS CARACOL, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(735, 'V141392995', 'MARLON ALEXIS VELANDIA GARCIA\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(736, 'E822211634', 'MAHER HABIB DIB \r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(737, 'J314158619', 'AGROPECUARIA EL POTRO SANO C A (AGROPECUARIA EL POTRO SANO C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(738, 'J301788931', 'COMERCIAL TROPICANA S R L (COMERCIAL TROPICANO SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(739, 'J310406600', 'AUTO SERVICIOS MONTALBAN C A (AUTO SERVICIO MONTALBAN, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(740, 'J304486731', 'TASCA DISCO SHOW MUSIC \"WILLOW C A\" (TASCA DISCO SHOW WILLOW C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(741, 'J080204727', 'CARNICERIA Y ABASTOS SANTA CRUZ C A (CARNICERIA Y ABASTOS SANTA CRUZ C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(742, 'E822555686', 'JIN CI WU   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(743, 'J310015694', 'INVERSIONES EL QUEBRADON C A (INVERSIONES QUEBRADON C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(744, 'J309868330', 'LICORERIA ANDREMAR, C.A (LICORERIA ANDREMAR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(745, 'E007380022', 'VICTOR MANUEL SAMAGAIO DA COSTA\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(746, 'J306796649', 'INVERSIONES ANDRYS 2000, C A (INVERESIONES ANDRYS 2000 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(747, 'J301253272', 'PANADERIA AVENIDA ESPAÑA C A (PANADERIA AVENIDA ESPAÑA C A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(748, 'J311998292', 'FAST COPY COMPANIA ANONIMA (FAST COPY COMPANIA ANONIMA    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(749, 'J307512954', 'LUBRIPARTES, C.A. (LUBRIPARTES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(750, 'J303328849', 'TABICA OCCIDENTE C.A. (TABICA OCCIDENTE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(751, 'J293900000', 'CORPORATIVA FERRETERA EL CRISTO, C.A. (COOPERATIVA FERRETERA EL CRISTO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(752, 'J070090898', 'LA CASA DE LOS TABACOS ELEAZAR BARROSO SUCESORES C.A (LA CASA DE LOS TABACOS ELEAZAR BARROSO SUCESOR', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(753, 'J303562507', 'LICORES PRIMAVERA, C.A (LICORES PRIMAVERA, C,A (LICOPRIMCA))', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(754, 'J296289972', 'FARMACIA NUEVA JALISCO C.A. (FARMACIA NUEVA JALISCO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(755, 'J308579467', 'SCRUB UNIFORMES MEDICOS, CA (SAD)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(756, 'J303382401', 'EL BODEGON DE LA CASA DE LOS TABACOS C.A. (EL BODEGON DE LA CASA DE LOS TABACOS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(757, 'J309840673', 'LICOLANDIA C.A (LICOLANDIA,CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(758, 'J295579195', 'LICOLANDIA PASEO URDANETA C.A (LICOLANDIA PASEO URDANETA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(759, 'J296740380', 'TORRES Y ROMERO UNIVERSAL DE PAPELERIA C.A. (T.R, UNIVERSAL DE PAPELERIA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(760, 'J309266667', 'INSTITUTE INTERNATIONAL NORA-MI COMPANIA ANONIMA (INSTITUTE INTERNATIONAL NORA-MI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(761, 'J304920598', 'CRIADORES AVICOLAS DEL ZULIA, C.A (CRIADORES AVICOLAS DEL ZULIA,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(762, 'J308558141', 'REPUESTOS  CAUCHOS YACAMBU II CA (REPUESTOS  CAUCHOS YACAMBU II CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(763, 'J308564850', 'REP. CAUCHOS YACAMBU I,C.A (REPUESTOS Y CAUCHOS YACAMBU I, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(764, 'J309797670', 'DAZA MAGGI PINTURAS, C.A (DAZA MAGGI PINTURAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(765, 'J295106378', 'FERRETERIA ARAZAURE COMPAÑIA ANONIMA (FRRETERIA ARAZAURE COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(766, 'J313454923', 'SUMINISTRO DE MATER.ELECTRICOS LA CONCEPCION, C.A. (SUMINISTRO DE MATER.ELECTRICOS LA CONCEPCION, C.', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(767, 'J313964328', 'MULTILIMPIO MACHIQUES C.A. (MULTILIMPIO MACHIQUES, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(768, 'J306114025', 'BAMBI SOUTH C.A (..)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(769, 'J070218878', 'RESTAURANT LA FAMILIA C.A. (RESTAURANT)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(770, 'J305889864', 'INVERSIONES COROMOTO C.A (INVERSIONES)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(771, 'J294472494', 'MIA´S KIDS C.A. (MIA´S KIDS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(772, 'J312870249', 'F.R.M. 2000 CA (FRM 2000,CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(773, 'J306364285', 'EL SITIO CAFE CA. (EL SITIO CAFE , C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(774, 'J302827167', 'GRAN COMERCIAL ITAL MEL CA (GRAN COMERCIAL ITAL-MEL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(775, 'J313042501', 'INVERSIONES LOS AMIGOS,C.A. (INVERSIONES LOS AMIGOS,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(776, 'J307015292', 'PROCESADORA ZULIANA DE ALIMENTOS, C.A. (PROCESADORA ZULIANA DE ALIMENTOS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(777, 'J309485105', 'QUE FINCA COMPANIA ANONIMA (QUE FINCA COMPANIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(778, 'J312490640', '`ISVI BOUTIQUE C,A (`ISVI BOUTIQUE C,A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(779, 'J295136048', 'SUPERMACHIQUES C.A (SUPERMACHIQUES C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(780, 'J311783113', 'NUNEZ CORPORACION SUR, COMPANIA ANONIMA (NUÑEZ CORPORACION SUR, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(781, 'J070044950', 'CLUB DEL COMERCIO (CLUB DEL COMERCIO )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(782, 'J312336986', 'CADENAS Y PINONES, C.A (CADENAS Y PINONES, C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(783, 'J315828448', 'SUCCO, COMPANIA ANONIMA (SD)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(784, 'J305987378', 'FERREMATERIALES EL NUEVO TENAMPA CA. (SDF)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(785, 'J310180474', 'MEGA REPUESTOS RAUL LEONI, C.A. (MEGA REPUESTOS RAUL LEONI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(786, 'J294167527', 'MEGA REPUESTOS RAUL LEONI LA LIMPIA CA (INVERSIONES MACK, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(787, 'J295530960', 'ESTUDIANTE EXPRESS C.A (ESTUDIANTE EXPRESS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(788, 'J070557532', 'NERVA STYLE ALTA PELUQUERIA C.A (NERVA STYLE ALTA PELUQUERIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(789, 'J296725349', 'TRIPOIDES DEL SUR, COMPAÑIA ANONIMA (TRISURCA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(790, 'J295229887', 'TU NUEVO REPUESTOS CONTRERAS,C.A. (TU NUEVO REPUESTOS CONTRERAS,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(791, 'J309476092', 'MARA-MAZDA, C.A. (A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(792, 'J296784477', 'SUPER MERCADO CHANG LONG C.A (SUPERMERCADO CHANG LONG, COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(793, 'J295632118', 'AUTO ACCESORIOS JUAN Y DANILO, C.A. (AUTO ACCESORIOS JUAN Y DANILO, C.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(794, 'J304817851', 'AUTO ESCAPES DE OCCIDENTE. NO.2 C.A (QWERTYUIOP)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(795, 'J316576043', 'FERRETERIA LA GRAN VICTORIA, C.A (FERRETERIA LA GRAN VICTORIA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17');
INSERT INTO `sisg_finalsclients` (`id`, `rif`, `description`, `name`, `lastName`, `phone`, `email`, `fiscalAddress`, `enable`, `creation_date`) VALUES
(796, 'J309421506', 'AUTO VIDRIOS Y ACCESORIOS LA VICTORIA, CA (VITO)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(797, 'J301523458', 'LICORES EL CHAPARRON, S.A (LICORES EL CHAPARRON C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(798, 'J315244519', 'INVERSIONES CIN, C.A. (INVERSIONES CIN, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(799, 'J090047328', 'PLOMECO SOCIEDAD ANONIMA (PLOMECO S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(800, 'J316969339', 'ANBLICK TECHNOLOGY C.A. (ANBLICK TECHNOLOGY C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(801, 'J302913080', 'TORNILLOS MARA, C.A. (TORNILLOS MARA C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(802, 'J314360981', 'FERRETERIA Y CERRAJERIA TORNIKAR, CA (FERRETERIA Y CERRAJERIA TORNIKAR, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(803, 'J313906980', 'ALQUISERCO, C.A. (ALQUISERCO C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(804, 'J302293570', 'EL LLANO C.A.PANADERIA  PASTELERIA (PANADERIA Y PASTELERIA EL LLANO, CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(805, 'J307259477', 'LA CASA DEL TURISTA CA (LA CASA DEL TURISTA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(806, 'J314303180', 'VEMZO C A (VEMZO C A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(807, 'J315240521', 'FARMACIA STA BARBARA CA (FARMACIA STA BARBARA , C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(808, 'J311450602', 'FARMACIA CIUDAD MARKET ROCHE, C.A (FARMACIA CIUDAD MARKET ROCHE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(809, 'J002260440', 'MARQUETERIA ANDREA, C.A. (MARQUETERIA ANDREA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(810, 'J296733295', 'INVERSIONES GUSPER 3208,. C.A (INVERSIONES GUSPER 3208,. C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(811, 'J310084394', 'EL REY DEL LICOR C.A (EL REY DEL LICOR C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(812, 'J001843981', 'LAVADO, ENGRASE Y RADIADORES GUARENAS, C.A. (LAVADO, ENGRASE Y RADIADORES GUARENAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(813, 'J305616663', 'SUPERMERCADO SUPER ECONOMICO CA (SUPERMERCADO SUPER ECONOMICO, C.A.  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(814, 'J307657740', 'AUTOMERCADO PALMA DEL ESTE C.A. (AUTOMERCADO PALMA DEL ESTE C,A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(815, 'J311654003', 'SUPERMERCADO GRAN ECONOMICO,C.A (SUPERMERCADO GRAN ECONOMICO,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(816, 'J296986479', 'INVERSIONES GERARDO 93 CA (INVERSIONES GERARDO 93 CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(817, 'J305529590', 'ELECTRODOMESTICOS GERARDO CA (ELECTRODOMESTICOS GERARDO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(818, 'J312945982', 'SETEMCA SOLUCIONES EN TELEFONIA MOVIL, C.A. (SETEMCA SOLUCIONES EN TELEFONIA MOVIL,CA   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(819, 'J316116328', 'INVERSORA XAGUAS C.A (INVERSORA XAGUAS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(820, 'J310319553', 'SAFEPIN C.A (SAFEPIN CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(821, 'V151764041', 'GERARDINA  ADRIANA SANCHEZ GUERRERO   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(822, 'J316084493', 'DECO-PLACA CONSTRUYE C.A (DECO-PLACA CONSTRUYE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(823, 'J314748556', 'LUTHIER CENTRO MUSICAL C.A. (LUTHIER CENTRO MUSICAL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(824, 'J314087070', 'REKARGA-2 JV. C.A. (RECARGA-2 JV, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(825, 'J309338285', 'DISTRIBUIDORA DE ALIMENTOS C.S.M.C., C.A (DISTRIBUIDORA DE ALIMENTOS C.S.M.C., C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(826, 'J003325325', 'TALLER DE JOYERIA 301 C.A (TALLER DE JOYERIA 301 C.A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(827, 'J308613037', 'INVERSIONES RIMOMAT C.A. (INVERCIONES RIMONAT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(828, 'J294302025', 'JOSS PRODUCCIONES Y DISEÑOS C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(829, 'J312338024', 'INVERSIONES LAS PIEDRAS AZULES C.A. (INVERSIONES LAS PIEDRAS AZULES,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(830, 'J311244174', 'ROU CAFE, C.A. (ROU CAFE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(831, 'J316585514', 'INVERSIONES TABHI ROSE, C.A. (INVERSIONES TABHI ROSE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(832, 'J311654941', 'CREACIONES STARFISH, C.A. (CREACIONES STARFISH, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(833, 'J315080710', 'INVERSIONES GOLD STYLE, C.A (INV. GOLD STYLE)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(834, 'J293948584', 'INVERSIONES GOLD CENTER 707, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(835, 'J002289651', 'COMERCIAL LIOR S R L (COMERCIAL LIOR, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(836, 'J308527149', 'JOYAS MOR, C.A. (JOYAS MOR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(837, 'J294673953', 'INVERSIONES PAT CHUAY C.A (INVERSIONES PAT CHUAY C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(838, 'J296076391', '¡OH QUE BUENO! 2021, C.A. (¡OH QUE BUENO! 2021, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(839, 'J003601799', 'TALLER MECANICO ALCIMAR C.A (TALLER MECANICO ALCIMAR C.A.  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(840, 'J305926972', 'INVERSIONES ANDRELIN C.A (INVERSIONES ANDRELIN C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(841, 'V032482836', 'VICTOR ANTONIO CARTAGENA ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(842, 'J304459173', 'REPRESENTACIONES JURUNGUE, C.A. (REPRESENTACIONES JURUNGUE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(843, 'J294984274', 'CORPORACION ZONA PC 2305, C.A. (ZONA PC)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(844, 'J003059390', 'ZAPATERIA BERMUDEZ I C A (ZAPATERIA BERMUDEZ)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(845, 'V161468025', 'NANCY JOHANNA YEPEZ CARRILLO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(846, 'J294645062', 'INVERSIONES ONIX DE OBATALA 8, C.A. (INVERSIONES ONIX DE OBATALA 8, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(847, 'J002812257', 'JOYERIA MAWI C A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(848, 'J316195856', 'JOYERIA MY DREAMS C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(849, 'J001797068', 'JOYERIA PEPILLO S R L (JOYERIA PEPILLO S R L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(850, 'J314463217', 'JOYERIA ERIKA E.T., C.A. (JOYERIA ERIKA E.T., C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(851, 'J307567473', 'JOYERIA DIAMONT C.A (JOYERIA DIAMONT C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(852, 'J001741224', 'JOYERIA MECHITA, C.A. (JOYERIA MECHITA, C.A.   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(853, 'J294521762', 'EXCLUSIVIDADES FHEYZARKS C.A. (EXCLUSIVIDADES FHEYZARKS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(854, 'J300419932', 'JOYERIA  Y TALLER OH CARIBE SRL (.JOYERIA Y TALLER OH CARIBE SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(855, 'J295133847', 'COMERCIAL HE JAMSA 3000, C.A. (COMERCIAL HE JAMSA 3000, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(856, 'J308635065', 'ITALIAMANIA C.A. (ITALIAMANIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(857, 'J306325719', 'DETALLES SARO, C.A (DETALLES SARO C,A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(858, 'J302181259', 'TALLER Y JOYERIA T.T.M S.R.L. (TALLER Y JOYERIA T.T.M. S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(859, 'J295912340', 'EL PLATO CRIOLLO DE AMARILIS (EL PLATO CRIOLLO DE AMARILIS)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(860, 'J313441929', 'NOVEDADES ROMARY, C.A. (NOVEDADES ROMARY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(861, 'J302207991', 'OLEAJE SURF SHOP, C.A. (EMPRESA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(862, 'J309768999', 'INVERSIONES J.V BARUTA C.A (INVERSIONES J.V.BARUTA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(863, 'J002454210', 'NOVEDADES EL PRIMO, S.R.L. (NOVEDADES EL PRIMO SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(864, 'J293998158', 'VARIEDADES RAMAR, C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(865, 'J309030795', 'X.O.T. BOUTIQUE C.A. (X.O.T. BOUTIQUE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(866, 'J304535287', 'BOUTIQUE SUGAR FREE 2002, C.A. (BOUTIQUE SUGAR FREE 2002, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(867, 'J305179913', 'AUTO FRENOS DARIO, C.A. (AUTO FRENOS DARIO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(868, 'J295515707', 'COMERCIALIZADORA VEROTEX C.A. (COMERCIALIZADORA VEROTEX C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(869, 'J293718899', 'FERREVIZCAYA,C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(870, 'J309650556', 'CREDITOS Y COMERCIALIZADORA EL MAGO, C.A. (CREDITOS Y COMERCIALIZADORA EL MAGO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(871, 'J001336214', 'TINTORERIA DE LUJO ALTO PRADO SRL (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(872, 'J305639450', 'INVERSIONES ECOEXPRESS, C.A. (INVERSIONES ECOEXPRESS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(873, 'J307956704', 'INVERSIONES ECOEXPRESS 2.000, C.A. (INVERSIONES ECOEXPRESS 2000, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(874, 'J312068493', 'LUGAKE, C.A. (LUGAKE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(875, 'J306341218', 'CORPORACION OMNIA C.A (CORPORACION OMNIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(876, 'J310049203', 'INVERSIONES LIMONZO, C.A. (INVERSIONES LIMONZO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(877, 'J306474447', 'INVERSIONES DESALMEIDA CA (INVERSIONES DESALMEIDA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(878, 'J001462651', 'TINTORERIA WASHING PLACE C.A. (TINTORERIA WASHING PLACE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(879, 'J000554390', 'LAVANDERIA Y TINTORERIA ROSA BLANCA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(880, 'J311258205', 'INVERSIONES FABYCO, C.A (INVERSIONES FABYCO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(881, 'J293803721', 'INVERSIONES SAC 51, C.A. (D)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(882, 'J314761005', 'INVERSIONES BLUE 27 C.A (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(883, 'J293742986', 'BISUTERIA LA COQUETA, O.M., C.A., (BISUTERIA LA COQUETA, O.M., C.A.,)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(884, 'J315042673', 'OPTICA MAGRAN, C.A. (OPTICA MAGRAN, C.A.     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(885, 'J002355190', 'DISTRIBUIDORA ALGALOPE, C.A (DISTRIBUIDORA ALGALOPE C A    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(886, 'J309006860', 'LAVANDERIA VICTORIA PLACE, C.A (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(887, 'J306055525', 'INVERSIONES EL NOGAL C.A (INVERSIONES EL NOGAL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(888, 'J308082090', 'MASCOTAS FELICES DISNEY, C.A. (MASCOTAS FELICES DISNEY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(889, 'J295946155', 'ASOC. COOPERATIVA DOCTORMOTO R.L. (ASOC. COOPERATIVA DOCTORMOTO R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(890, 'V063420316', 'BIAGIO YACOBONE \r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(891, 'J295391684', 'INVERSIONES LAGO EXPRESS, COMPAÑIA ANONIMA (INVERSIONES LAGO EXPRESS, COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(892, 'J307253363', 'REPRESENTACIONES ABACUS CA (,)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(893, 'J305920850', 'BRAVENPORT, C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(894, 'J309270427', 'CORPORACION PENTESILEA C.A. (FF)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(895, 'J316374750', 'TRUC MODAS 2010, C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(896, 'J309909690', 'VESTIR 3005, C.A. (\"VESTIR 3005, C.A\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(897, 'J314286420', 'REPRESENTACIONES IVSHEL C.A (\"REPRESENTACIONES IVSHEL,C.A.\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(898, 'J315019299', 'MENSCH INVERSIONES C.A. (MENSCH INVERSIONES C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(899, 'J306992847', 'INVERSIONES JOSMICAR, C.A (INVERSIONES JOSMICAR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(900, 'J296992576', 'ARAYA SERVICIOS GASTRONÓMICOS C.A. (ARAYA SERVICIOS GASTRONÓMICOS)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(901, 'J300400417', 'FRIGORIFICO EL LORO J.P CA (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(902, 'J312284412', 'CINTAS Y MUCHO MAS, C.A. (M)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(903, 'J316181081', 'INVERSIONES ALVAMAR,C.A. (INVERSIONES ALVAMAR,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(904, 'J307816910', 'FERRETERIA DON PEDRO,  C.A (FERRETERIA DON PEDRO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(905, 'J310319723', 'INVERSIONES ARYANDRES CA (INVERSIONES ARYANDRES CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(906, 'J312306173', 'DISTRIBUIDORA JAVILA C.A (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(907, 'J070266317', 'LIBRERIA SAN AGUSTIN S A (LIBRERIA SAN AGUSTIN S A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(908, 'J293637007', 'RESPUESTOS OLMOS C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(909, 'J070105542', 'FERRETERIA ZULIA.C.A (FERRETERIA ZULIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(910, 'J314746316', 'MOTO MECANICA OSCAR C.A (MOTO MECANICA OSCAR C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(911, 'J295945400', 'COMERCIALIZADORA SOLO MODAS,C.A (COMERCIALIZADORA SOLO MODAS,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(912, 'J309879251', 'TASCA RESTAURANT EL TUNEL DE LA ESTANCIA, C.A. (TASCA RESTAURANT EL TUNEL DE LA ESTANCIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(913, 'V138224712', 'AMPARO ACEVEDO NARANJO   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(914, 'J312012684', '\"INVERSIONES ENMANUEL, C.A.\" (INVERSIONES ENMANUEL,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(915, 'J294955991', 'ALIMENTOS TUGNOLI C.A. (ALIMENTOS TUGNOLI C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(916, 'J003021725', 'VARIEDADES J.H., C.A. (VARIEDADES J.H., C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(917, 'J312036478', 'DISTRIBUIDORA DE LICORES (DILICA), CA (DISTRIBUIDORA DE LICORES (DILICA), CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(918, 'V027796717', 'JUAN DE JESUS RAMIREZ    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(919, 'J293954444', 'CYBER NEO 16, C.A. (CYBER NEO 16 ,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(920, 'J313495255', 'AUTO PARTS EJIDO, CA (AUTO PARTS EJIDO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(921, 'J315046482', 'COMIDA CRIOLLA MARIA IGNACIA C.A. (COMIDA CRIOLLA MARIA IGNACIA C.A.   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(922, 'J307455730', 'INVERSIONES TU LICOR C.A (INVERSIONES TU LICOR C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(923, 'J312302577', '\"TU CYBER @1,C.A\" (\"TU CYBER @1, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(924, 'J296397791', 'LO + CHIC BISUTERÍA, C.A. (LO + CHIC BISUTERÍA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(925, 'V075595057', 'MARCOS TULIO MARQUEZ AVILA  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(926, 'J000811695', 'LENCERIAS Y CANASTILLAS KATIUSKA SRL (LENCERIAS Y CANASTILLAS KATIUSKA SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(927, 'J296514283', 'SALON DE BELLEZA RULOS, C.A. (SALON DE BELLEZA RULOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(928, 'J303474187', 'FARMACIA 16 SEPTIEMBRE C.A. (FARMACIA 16 SEPTIEMBRE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(929, 'J294497527', 'TIENDA NATURISTA LA REMOLACHA C.A (TIENDA NATURISTA LA REMOLACHA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(930, 'J295545231', 'J0HN MAR, C.A. (JOHN MAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(931, 'J296692599', 'INVERSIONES CHIP CHIC, C.A (INVERSIONES CHIP CHIC, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(932, 'V051217167', 'ORLANDO JOSE GUARAMATO SAMIER\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(933, 'J314053019', 'PANADERIA Y PASTELERIA EL SAMAN GUATIREñO CA (PANADERIA Y PASTELERIA EL SAMAN GUATIREÑO CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(934, 'J293913756', 'VIVERO LAS TRES J C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(935, 'J303151957', 'MULTISERVICIOS 3F C.A. (MULTISERVICIOS 3F C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(936, 'V037289848', 'GARCIA DE SANCHEZ GENEROSA  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(937, 'V015751980', 'MIGUEL ANGEL GOMEZ ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(938, 'J305857431', 'ALMACEN ZAPATA CA (ALMACEN ZAPATA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(939, 'J309089374', 'IMPOSAM C.A. (IMPOSAM)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(940, 'J313111813', 'CONCESIONARIOS A.C UNION CANARIA DE VENEZUELA (XXXX)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(941, 'J310783667', 'INVERSIONES SOLUNTO, C.A. (INVERSIONES SOLUNTO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(942, 'J310800383', 'LA REUNION C A (LA REUNION C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(943, 'J310282838', 'A/C LA GRAN PROVEEDURIA ESTUDIANTIL F.C.U. (A/C LA GRAN PROVEEDURIAESTUDIANTIL F.C.U)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(944, 'J311101268', 'ASOCIACION CIVIL EL LIDER (ASOCIACION CIVIL EL LIDER)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(945, 'J306605576', 'FARMACIA FARMA HELP, C.A. (FARMACIA FARMA HELP C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(946, 'V120737232', 'SAID KASSAM AL HENNAWI AL HENNAWI     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(947, 'V075057730', 'DARVING ALBERTO GONZALEZ FONSECA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(948, 'J300918106', 'ALMACEN CASA DEL PUEBLO S A (ALMACEN CASA DEL PUEBLO, S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(949, 'J090179992', 'MESON LA CIBELES S.R.L (SIN)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(950, 'J090254501', 'FARMACIA ALTO CHAMA C A (FARMACIA ALTO CHAMA C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(951, 'J090008098', 'TINTORERIA Y LAVANDERIA EXTRA C A (TINTORERIA Y LAVANDERIA EXTRA C A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(952, 'J000061890', 'CECILE C A (CECILE C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(953, 'J304271336', 'COMERCIAL FETTA, C.A. (COMERCIAL FETTA. C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(954, 'J302922879', 'LUMI ARTE LM 95 (LUMI ARTE LM 95)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(955, 'J302179530', 'GRUPO LA CITE CA (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(956, 'J316030318', 'PRODUCTOS NATURALES ANATO C.A (PRODUCTOS NATURALES ANATO C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(957, 'V034821700', 'AMELIA CRISTINA COZIER DE GORDONES    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(958, 'J294518389', 'AUTO LP SERVICES, C.A. (AUTO LP SERVICES, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(959, 'J296638365', 'CAPELLI´S CENTER, C.A (CAPELLI´S CENTER, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(960, 'J307106557', 'SUC.HUNG FUNG PO NING (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(961, 'J295606435', 'EL CAMPANARIO EXPRESS, C.A. (Z)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(962, 'J313679402', 'FLORISTERIA Y DECORACIONES LA NURIA C.A (FLORISTERIA Y DECORACIONES LA NURIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(963, 'J314196189', 'MATERIALES NUEVA PACAIRIGUA CA (MATERIALES NUEVA PACAIRIGUA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(964, 'J308562211', 'FASHION BLUE C.A (FASHION BLUE C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(965, 'E819851380', 'HOLM ALBERTO MARTINEZ    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(966, 'J314938193', 'LA DIOSA SALVAJE C.A (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(967, 'J305726620', 'TACOS LOS COMPADRES S.R.L (TACOS LOS COMPADRES S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(968, 'J296131970', 'VIVERO LOS NIETOS 1943, C.A (VIVERO LOS NIETOS 1943, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(969, 'J294303358', 'VIVERO JILVIER 05-80, C.A. (VIVERO JILVIER 05-80, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(970, 'V030128180', 'ISAURA JISELA ACOSTA     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(971, 'J297076034', 'BAZAR BISUCENTER BLAYON, C.A. (BAZAR BISUCENTER BLAYON, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(972, 'J311002596', 'SHOPPING EXCLUSIVIDADES C.A (SHOPPING EXCLUSIVIDADES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(973, 'J295820690', 'TIPOGRAFIA Y PUBLICIDAD ROJAS, C.A. (TIPOGRAFIA Y PUBLICIDAD ROJAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(974, 'V110778518', 'ZENIT MARIBEL GONZALEZ JIMENEZ\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(975, 'V127103719', 'JOSE RAFAEL LUCENA ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(976, 'V011219680', 'CARLOS LOPEZ   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(977, 'V042014440', 'OMAR VICENTE TORRES', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(978, 'V037665173', 'LUIS ALBERTO CARRILLO QUINTERO\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(979, 'V037664614', 'OMAR HUMBERTO CARRILLO QUINTERO\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(980, 'J314210033', 'INVERSIONES ANASAN, C.A. (INVERSIONES ANASAN, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(981, 'J313408522', 'M FASHION C A (M FASHION C A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(982, 'J316900029', 'CODIGO ACCESORIOS C A (CODIGO ACCESORIOS, C. A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(983, 'J315195984', '\"LICORERIA INVERSIONES EL VERDUGO C.A.\" (\"LICORERIA INVERSIONES EL VERDUGO C.A.\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(984, 'V146923263', 'TERESA DE LOS A. GONZALEZ S ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(985, 'J302818150', 'ABASTOS  Y LICORERIA JHAN, S.R.L. (ABASTOS Y LICORERIA JHAN, S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(986, 'J293666341', 'INVERSIONES VVBR, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(987, 'J314319132', 'TRAPITOS SHOP C A (TRAPITOS SHOP C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(988, 'J314765981', 'DELICATESSES MARILU C.A. (DELICATESSES MARILU,  C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(989, 'J303429599', 'DISTRIBUIDORA LAGOMAR CA (DISTRIBUIDORA LAGOMAR CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(990, 'V083097406', 'MIRIAN JOSEFINA BELLORIN ALCALA\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(991, 'J311520791', 'INTEL COMPUTACION CA (INTEL COMPUTACION, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(992, 'J302474183', 'ESTACION DE SERVICIOS ZARAZA C.A (ESTACION DE SERVICIOS ZARAZA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(993, 'J313335142', 'ENZOPELLE C.A. (ENZOPELLE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(994, 'J297049894', '\"EXTREME COMPUTER, C.A\", (\"EXTREME COMPUTER, C.A\",)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(995, 'J293507863', '\"JES  FRAN, C.A\" (\"JES  FRAN, C.A\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(996, 'J309290240', 'PRECISION STORE S R L (PRECISION STORE S R L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(997, 'J313014311', 'AREPERA EL GRAN PODER DIVINO C.A. (AREPERA EL GRAN PODER DIVINO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(998, 'J075046412', 'REENCAUCHADORA SAN AGUSTIN C A (REENCAUCHADORA SAN AGUSTIN C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(999, 'J300538567', 'INVERSORA 1926 C A (INVERSORA 1926 C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1000, 'J006596931', 'CRISTALERIA VASSALLO CA (CRISTALERIA VASSALLO,CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1001, 'J310901805', 'CRISTALERIA VASSALLO 2003 C.A (CRISTALERIA VASSALLO 2003 C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1002, 'J311103171', 'CRISTALERIA VASSALLO 2.004, C.A. (CRISTALERIA VASSALLO, 2004, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1003, 'J294550231', 'INVERSIONES TECNI-SOLUCIONES LA VILLA C.A. (INVERSIONES TECNI-SOLUCIONES LA VILLA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1004, 'J309986767', 'FARMACIA EL BIENESTAR II, C.A. (FARMACIA EL BIENESTAR)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1005, 'J309240064', 'FARMACIA EL BIENESTAR, C.A. (FARMACIA EL BIENESTAR)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1006, 'J296292604', 'FERREACRILICOS LA AGUADITA C.A (FERREACRILICOS LA AGUADITA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1007, 'J293987237', 'FARMACIA EL BIENESTAR DELICIAS NORTE, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1008, 'J310896755', 'LA POLLERA, C.A (LA POLLERA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1009, 'J296949239', 'CORPORACION ML, C.A. (CORPORACION ML, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1010, 'J307706554', 'MUNDO CANINO C.A (MUNDO CAMINO)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1011, 'J308883743', 'BORDADO DIGITAL EMPRESARIAL, C.A. (BORDADO DIGITAL EMPRESARIAL C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1012, 'J305808694', 'CASIO SPORT C.A (CASIO SPORT C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1013, 'J309259334', 'CASIO SHOP, C.A. (CASIO SHOP, C.A.  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1014, 'J308806595', 'CASIO GALERIAS COMPANIA ANONIMA (CASIO GALERIAS MALL COMPANIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1015, 'J310709904', 'DISTRIBUIDORA Q`BISU, C.A. (Q`BISU C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1016, 'J308806625', 'CASIO DORAL COMPANIA ANONIMA (CASIO DORAL COMPANIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1017, 'J312167424', 'PLUS FARMACIA C.A. (PLUS FARMACIA C-A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1018, 'J311618201', 'FARMACIA HOSPITALIDAD,SRL. (FARMACIA HOSPITALIDAD,SRL.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1019, 'J315949822', 'FARMACIA CATATUMBO C.A (FARMARCIA CATATUMBO C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1020, 'J311764429', 'FARMACIA CUMBOTO SUR S.R.L. (FARMACIA CUMBOTO SUR S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1021, 'J305885907', 'FARMACIA LA GRAN COLOMBIA CA. (FARMACIA LA GRAN COLOMBIA CA.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1022, 'J303694241', 'FARMACIA EL CENTRO CA (FARMACIA EL CENTRO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1023, 'J304219890', 'TINTORERIA Y LAVANDERIA VENEZUELA C.A (TINTORERIA VENEZOLANAS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1024, 'J309017950', 'CLOSETS SHOP, S.A. (CLOSETS SHOP, S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1025, 'J310020302', 'FARMACIA BOLIVARIANA BELLA VISTA, C.A. (FARMACIA BOLIVARIANA BELLA VISTA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1026, 'J306993924', 'KOMERCIAL DON CARLOS,C.A. (KOMERCIAL DON CARLOS, C .A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1027, 'J294697267', 'DOCTOR FARMACIA EL TURF. COMPAÑIA ANONIMA (DOCTOR FARMACIA EL TURF. COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1028, 'J293946620', 'STATUS MODAS,C.A. (THELFO,CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1029, 'J309093584', 'PC-TEL MACHIQUES C.A (PC-TEL MACHIQUES C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1030, 'J305106894', 'VIDRIO AUTO MACHIQUES C A. (VIDRIO AUTO MACHIQUES C A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1031, 'J295319690', '\"VIDRIOS Y CARROCERIA BUENA VISTA EL POTENTE,C.A\" (\"VIDRIOS Y CARROCERIA BUENA VISTA EL POTENTE,C.A\"', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1032, 'J309132237', 'PC-TEL LA VILLA C.A (PC-TEL LA VILLA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1033, 'J304029462', 'REDOLANDIA C.A. (REDOLANDIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1034, 'J294631045', 'INVERSIONES D.J. SURF SKATE, C.A. (INVERSIONES DE SURF SKATE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1035, 'J305459231', 'INVERSIONES NEWGAP, C A (INVERSIONES NEWGAP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1036, 'J314402170', 'HOTEL CALIFORNIA 69 C A (HOTEL CALIFORNIA 69 C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1037, 'J307658908', 'CALIFORNIA 13  C A (CALIFORNIA 13 C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1038, 'J313894400', 'MERCERIA EL BOTON DORADO C A (MERCERIA EL BOTON DORADO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1039, 'J080262042', 'EL NAVEGANTE,C.A. (EL NAVEGANTE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1040, 'J300414752', 'DRUGSTORE,C.A. (DRUGSTORE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1041, 'J311426906', 'COMERCIAL ARTE HOGAR, C.A. (COMERCIAL ARTE HOGAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1042, 'J296595453', 'SABOR Y SAZON 8A, C.A. (SABOR Y SAZON 8A, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1043, 'J293968496', 'INVERSIONES LA MEDIA DOCENA II, C.A. (INVERSIONES LA MEDIA DOCENA II, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1044, 'J310447357', 'INVERSIONES A.M.K. 1582 CA (INVERSIONES A.M.K.1582 C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1045, 'J313585203', 'SUPERMERCADO ROSTOL, C. A. (XX)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1046, 'J001136070', 'CENTRO OPTICO MACARACUAY, S.R.L. (CENTRO OPTICO MACARACUAY , S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1047, 'J000825408', 'SUPERMERCADO ATLANTICO CARIBE CENTRAL SRL (SUPERMERCADO ATLANTICO CARIBE CENTRAL S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1048, 'J303432735', 'PARRILLA EL NACIONAL C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1049, 'J315341310', 'CREACIONES JM JAQMAR CA (CREACIONES JM JAQMAR,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1050, 'J313688649', 'AUTOLAVADO MACARACUAY, C.A. (AUTOLAVADO MACARACUAY, C.A.   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1051, 'J307772956', 'BAR RESTAURANT FU XING C.A (BAR RESTAURANT FU XING C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1052, 'J295128126', 'INVERSIONES ALSUNA D.A.,C.A. (INVERSIONES ALSUMA D.A.,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1053, 'J308615161', 'MATRIX CAR AUDIO, C.A (MATRIX CAR AUDIO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1054, 'J294873219', 'ARABESHKAA, C.A (ARABESHKAA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1055, 'J295088965', 'CHIC FASHION C.A. (CHIC FASHION C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1056, 'J295084811', 'INVERSIONES SO PRA TI, C.A. (INVERSIONES SO PRA TI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1057, 'J315312573', 'MANUFACTURAS GIGI IMPORT C.A (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1058, 'J295163800', 'INVERSIONES GIANINA, C.A (INVERSIONES GIANINA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1059, 'J295270933', 'BOUTIQUE SIMONEI DANIELA C.A. (BOUTIQUE SIMONEI DANIELA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1060, 'J295163096', 'INVERSIONES GLADYS E.M.P. 2032, S.A. (INVERSIONES GLADYS E.M.P. 2032, S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1061, 'J294982735', 'INVERSIONES EL PEQUEÑO NABIL, C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1062, 'J295109881', 'TRILLISOS CAMA,CA (TRILLISOS CAMA, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1063, 'J001322264', 'DISERIMET C A (DISERIMET)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1064, 'J002007583', 'ESTACION DE SERVICIO AGUA SALUD S R L (ESTACION DE SERVICIO AGUA SALUD S R L     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1065, 'J315312999', 'RESTAURANT ESCORPION FOODS EXPRESS, C.A (RESTAURANT ESCORPION FOODS EXPRESS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1066, 'J294553028', 'NOVEDADES KARINEL Z.S C.A (NOVEDADES KARINEL Z.S C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1067, 'J305675988', 'POOL GUAICAIPURO, C.A. (POOL GUAICAIPURO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1068, 'J000739650', 'BAR RESTAURANT CERVECERIA LLAGUNO CA (BAR RESTAURANT CERVECERIA LLAGUNO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1069, 'J000939195', 'BAR RESTAURANT TASCA A RODA, S.R.L. (BAR-RESTAURANT-TASCA A RODA,S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1070, 'V117396467', 'CARLOS SANTIAGO PADRON CABRILES\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1071, 'J002651490', 'LA TASCA DE CAMOES RESTAURANT C.A. (LA TASCA DE CAMOES RESTAURANT SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1072, 'J003633046', 'GREGORIO JOSE SUCESION DE JOSE GREGORIO LEITAO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1073, 'J313726958', 'INVERSIONES BENFAR CA (X)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1074, 'J315082500', 'COMERCIAL RIO ROJO C.A. (COMERCIAL RIO ROJO C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1075, 'J309244965', 'LIBRERIA DEPORTIVA II, C.A. (.LIBRERIA DEPORTIVA II, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1076, 'J295289359', 'DISTRIBUIDORA AMALIA 2004, C.A. (DISTRIBUIDORA AMALIA 2004, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1077, 'J000899037', 'GARAGE EL RETORNO C.A. (GARAGE EL RETORNO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1078, 'J003616605', 'GARAGE CAMPU CASU C.A. (GARAGE CAMPU CASU C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1079, 'J003496014', 'ESTACIONAMIENTO PARQUE CARACAS DOS  C A (ESTACIONAMIENTO PARQUE CARACAS DOS  C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1080, 'J309066625', 'SUPER VIVERES ORIENTE, C.A. (TERYUW)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1081, 'J304880383', 'VIVERES RIDOLFO, C.A. (VIVERES RIDOLFO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1082, 'J304761287', 'IMPORTADORA F.P.O.21 CA (IMPORTADORA F.P.O. 21)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1083, 'J296219583', 'KPRICHITOS INFANTILES, C.A. (KPRICHITOS INFANTILES)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1084, 'J314070169', 'CAFFE SWIMWEAR, CA (CAFFE SWIMWEAR, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1085, 'J309144391', 'INBRIGO, C.A. (INBRIGO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1086, 'J316718158', 'PET SCHOP MILENIUM C.A (PET SCHOP MILENIUM C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1087, 'J316334490', 'RODRIGUEZ Y FIGUERA C A (RODRIGUEZ Y FIGUERA C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1088, 'J296031347', 'CRISTALERIA CANAIMA TINO CA (CRISTALERIA CANAIMA TINO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1089, 'J296466149', 'RADICAL AUDIO C A (RADICAL AUDIO C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1090, 'J304645350', 'CAR SISTEM S C A (CAR SISTEM S   C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1091, 'J303635660', 'OPTI CENTER C A (OPTICENTER)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1092, 'J307517778', 'KENZO SPORT WEAR C A (KENZO SPORT WEAR, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1093, 'J303543367', 'EL GAVILAN II, C.A (EL GAVILAN II, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1094, 'J296964165', 'MIMO SPORT, C.A. (MIMO SPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1095, 'J310240302', 'B.S.N DE MARGARITA, C.A. (B.S.N DE MARGARITA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1096, 'J300074927', 'LA BELLA DAMA C A (LA BELLA DAMA, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1097, 'J300826848', 'KATRY AUTO ACCESORIO CA (TECNOLUZ PUERTO LA CRUZ C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1098, 'J295262965', 'COMERCIAL LOS CARLOS, C.A (COMERCIAL LOS CARLOS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1099, 'J315353687', 'PRONTO MODA C.A (PRONTO MODA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1100, 'J304865740', 'INVERSIONES L.W.K,C.A. (INVERSIONES L.W.K.C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1101, 'J293622867', 'MILI.COM, C.A. (MILI.COM, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1102, 'J293622760', 'POWER MAX, C.A. (POWER MAX, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1103, 'J315787130', 'MONIK C.A. (MONIK, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1104, 'J293643805', 'HOGAR PLAZA,C.A (HOGAR PLAZA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1105, 'J310276382', 'NAGOYA, C.A (NAGOYA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1106, 'J293624029', 'AUDIO PLAZA ZAMORA, C.A. (AUDIO PLAZA ZAMORA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1107, 'J315726920', 'MIAMI PLAZA, C.A (MIAMI PLAZA, C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1108, 'J293643961', 'GALAXI HOGAR,C.A (GALAXI HOGAR)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1109, 'J065119055', 'VIVERO PORLAMAR, C.A. (VIVERO PORLAMAR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1110, 'J293734436', 'VITUNI IMPORT,C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1111, 'J308011029', 'GALA SHOP, C.A (GALA SHOP, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1112, 'J295490488', 'FERRETOTAL ELECTRIC IMPORT, C.A (FERRETOTAL ELECTRIC IMPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1113, 'J314562118', 'MOBILUM CENTER C.A (MOBILUM CENTER, COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1114, 'J065070200', 'EL PEDREGALAZO, C.A. (EL PEDREGALAZO, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1115, 'J308459550', 'FUNITEL, C.A. (FUNITEL, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1116, 'J065075864', 'SUPPLY OFICINA MARGARITA, C.A. (SUPPLY OFICINA MARGARITA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1117, 'J293676770', 'ITCGAMES, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1118, 'J295755422', 'FERREDHANIELA, C.A (FERREDHANIELA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1119, 'J309542818', 'CENTRO HIPICO LA FIERA, C.A. (CENTRO HIPICO LA FIERA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1120, 'V169316160', 'LAURA DEL VALLE GOMEZ MARCANO\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1121, 'J311292888', 'COMERCIAL ANGELA ALBINA GONZALEZ, C.A. (COMERCIAL ANGELA ALBINA GONZALEZ C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1122, 'J316741524', 'FERREIMPORT C.A (FERREIMPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1123, 'J294729320', 'COMERCIAL LA ASUNCION, C.A. (COMERCIAL LA ASUNCION)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1124, 'J307409614', 'FERRETERIA HNOS R  R C.A (FERRETERIA HNOS R  R C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1125, 'J315059797', 'BODEGON EUROPLAZA C.A (BODEGON EUROPLAZA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1126, 'J065032596', 'ZULOAGA SPORT CA (ZULOAGA SPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1127, 'J065090251', 'COMERCIAL ANGEL C A (COMERCIAL ANGEL C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1128, 'J080033698', 'IMPORTADORA NUEVA ESPARTA S.A (ADAN Y EVA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1129, 'J311419284', 'LICORERIA Y CHARCUTERIA LA PARAULATA, C.A (LICORERÍA Y CHARCUTERÍA LA PARAULATA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1130, 'J065062274', 'FERRETERIA LA R S R L (FERRETERIA LA R, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1131, 'J315175975', 'AUTOREPUESTOS LOLA C.A (AUTOREPUESTOS LOLA C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1132, 'J296190895', 'BODEGON LAS DELICIAS C.A (BODEGON LAS DELICIAS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1133, 'J065035773', 'RANCHO TIPICO MANDINGA C A (RANCHO TIPICO MANDIGA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1134, 'J308798720', 'COMERCIAL JINS C.A (COMERCIAL JINS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1135, 'J295526121', 'LA TORRE DE PISA, C.A. (LA TORRE DE PISA. C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1136, 'J313836885', 'COPIAS Y TRANSCRIPCIONES DE MARGARITA C.A (COPIAS Y TRANSCRIPCCION DE MARGARITA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1137, 'J293530857', 'MOUSSA SHOP, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1138, 'J306276181', 'DISTRIBUIDORA BOLEROS IMPORT, C.A. (DISTRIBUIDORA BOLEROS IMPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1139, 'J308836710', 'NICO BOUTIQUE,C.A. (NICO BOUTIQUE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1140, 'J293960690', 'DE LUX ELECTRONIC, C.A. (DE LUX ELECTRONIC, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1141, 'J295271549', 'YOURSELF GROUP, C.A (YOURSELF GROUP, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1142, 'J308385042', 'SPORT 2000, C.A. (SPORT 2000, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1143, 'J065078030', 'INVERSIONES EL ESPINAL C A (INVERSIONES EL ESPINAL,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1144, 'J293663415', 'COMERCIAL MOROCHA BELLA, C.A. (COMERCIAL MOROCHA BELLA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1145, 'J080025318', 'SERVICENTRO DE CAUCHOS PORLAMAR C.A (SERVICENTRO DE CAUCHOS PORLAMAR)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1146, 'J312665173', 'CARMELA SALON DE BELLEZA C.A. (CARMELA SALON DE BELLEZA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1147, 'J296061696', 'STAMPS EXPRESS C.A. (STAMPS EXPRESS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1148, 'J312789123', 'FERRETERIA EL GUAYAMURI, C.A. (FERRETERIA EL GUAYAMURI, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1149, 'V101973430', 'PETRA MARIA ( FARMACIA PUEBLO NUEVO ,FP ) MARTIN LUGO   \r\n\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1150, 'J308618586', 'INVERSIONES NAWAL,C.A. (INVERSIONES NAWAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1151, 'J316837882', 'SHAMS ELECTRONICS C.A (BANCO COMUNAL CASTILLO XXI R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1152, 'J293833361', 'GALERY FANTASY C.A. (GALERY FANTASY)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1153, 'J301870751', 'SUPERMERCADO GRAN FORTUNA I CA (SUPERMERCADO GRAN FORTUNA I CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1154, 'J296587124', 'LOS GUARIQUEÑOS RAM, C.A. (LOS GUARIQUEÑOS RAM, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1155, 'J065094990', 'CASA DEL CUERO, TAURO PIEL, C.A. (CASA DEL CUERO TAURO PIEL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1156, 'J293614660', 'TAURO PIEL II C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1157, 'J314130862', 'CUEROS Y PIELES C.A (CUEROS Y PIELES C.A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1158, 'J302144566', 'EL GANADERO, C.A (EL GANADERO, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1159, 'J065114231', 'NUEVO KIOSKO GUAIQUERI C.A (NUEVO KIOSKO GUAQUERI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1160, 'J300502210', 'SILK C A (SILK C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1161, 'J308899054', 'BICITEK SPORT C.A (BICITEK SPORT C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1162, 'J305907919', 'FINOMAR C.A (INVERSIONES LOBENIO C,A,)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1163, 'J305158045', 'IMPORTADORA BALLISTIC, C.A. (IMPORTADORA BALLISTIC, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1164, 'J065008423', 'IMPORTADORA NADIME C A (IMPORTADORA NADIME, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1165, 'J295324596', 'TIENDAS EXITO CENTER, C.A (TIENDAS EXITO CENTER, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1166, 'J306846999', 'SAMARA FASHION C.A (SAMARA FASHION)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1167, 'J316435822', 'AQUA CIJ, C.A. (AQUA CIJ, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1168, 'J065010177', 'CUCHITA CA (CUCHITA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1169, 'J310085285', 'DISTRIBUIDORA LA PACHANGA, C.A (DISTRIBUIDORA LA PACHANGA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1170, 'J308907804', 'AUTO-REPUESTOS MICO S.A (AUTO REPUESTOS MICO S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1171, 'J301057120', 'NANA IMPORT, CA (SUMINISTROS E INSUMOS PARA CAÑICULTORES CARORA, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1172, 'J313315494', 'V.V.W C.A (V.V.W, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1173, 'J309995111', 'REPUESTOS JOSSMAR, C.A. (REPUESTOS JOSSMAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1174, 'J307899131', 'MUEBLERIA EL OFERTON C.A (MUEBLERIA EL OFERTON, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1175, 'J310388830', 'MUEBLES LA UNION, C.A. (MUEBLES LA UNION C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1176, 'J307473584', 'F  V TRADING CORPORATION C.A (F  V TRADING CORPORACIÓN, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1177, 'J293972833', 'FRIO AUTO SERVICE C.A (FRIO AUTO SERVICE C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1178, 'J305435103', 'MAYOR Y DETAL DE VIVERES MADEVICA C.A (MAYOR Y DETAL DE VIVERES MADEVICA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1179, 'J311171827', 'COMERCIAL REFRELUIS, C.A. (COMERCIAL REFRELUIS,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1180, 'J315847272', 'EL MADAR,C.A (EL MADAR,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1181, 'J300548392', 'FESTEJOS Y LICORERIA PA LA FIESTA, C.A. (FESTEJOS Y LICORERIA PÁ LA FIESTA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1182, 'J308447455', 'REPRESENTACIONES EL INDIO,C.A. (REPRESENTACIONES EL INDIO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17');
INSERT INTO `sisg_finalsclients` (`id`, `rif`, `description`, `name`, `lastName`, `phone`, `email`, `fiscalAddress`, `enable`, `creation_date`) VALUES
(1183, 'J309565427', 'WORLD JEANS, C.A (WORLD JEANS, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1184, 'J315375117', 'COCODRILO JEANS, C.A. (COCODRILO JEANS, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1185, 'J306762140', 'HIBA IMPORT III, C.A (HIBA IMPORT III, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1186, 'J312979062', 'IMPORT CENTER, C.A. (IMPORT CENTER, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1187, 'J309557335', 'TECNI REPUESTOS COA,  C.A (TECNI REPUESTOS COA,  C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1188, 'J302568609', 'IMPORTADORA LA GUAIRA II C.A (IMPORTADORA LA GUAIRA II)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1189, 'J065043776', 'DISTRIBUIDORA TIFANI C.A (DISTRIBUIDORA TIFANI C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1190, 'V116440195', 'LOLIMAR FLORANGEL VASQUEZ MATA\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1191, 'J295467311', '\"STAMPS FRANELAS C. A.\" (STAMPS FRANELAS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1192, 'J312420731', 'DISTRIBUIDORA EN MGTA DE PROD.ALIMENTICIOS DIMPACA, C.A (DIMPACA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1193, 'J295197802', 'ZOLO SPORT, C.A. (ZOLO SPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1194, 'J293694051', 'KAUKAB INTERNACIONAL, C.A (KAUKAB INTERNACIONAL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1195, 'J065035811', 'FERRE AZUL C A (FERRE AZUL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1196, 'J315144476', 'EL CABILLAZO C.A (EL CABILLAZO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1197, 'J316924157', 'COMERCIAL MESSINA, C.A (COMERCIAL MESSINA, C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1198, 'J302733804', 'FARMACIA SAN MIGUEL ARCANGEL C.A (FARMACIA SAN MIGUEL ARCANGEL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1199, 'J294171320', 'AUTOSERVICIOS JAM, C.A (AUTOSERVICIOS JAM, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1200, 'J065038772', 'CERVEC Y REST TABERNA DEL MAR, C.A. (CERVECERIA Y RESTAURANTE TABERNA DEL MAR)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1201, 'J314787276', 'INVERSIONES DANI, C.A (INVERSIONES DANI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1202, 'J295775989', 'FIMASIS SOLUCIONES IMPORT C.A (FIMASIS SOLUCIONES IMPORT C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1203, 'J310831289', 'SERVICENTRO DE CAUCHOS PLAZA, C.A (SERVICENTRO DE CAUCHOS PLAZA,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1204, 'J295230338', 'ROMARCA INVERSIONES, C.A. (RECARGATE)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1205, 'J315483556', 'PANADERIA,PASTELERIA Y CHARCUTERIA CARACAS, C.A (PANADERIA,PASTELERIA Y CHARCUTERIA CARACAS.  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1206, 'J304062478', 'EL REFUGIO DE MIS PADRES, C.A (EL REFUGIO DE MIS PADRES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1207, 'J316566692', 'UNIVIVERES, C.A. (UNIVIVERES, C.A.  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1208, 'J294414630', 'FENIX INTERNACIONAL, C.A. (FENIX INTERNACIONAL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1209, 'J312571357', 'DUROMAX, C.A (DUROMAX, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1210, 'J312698160', 'FARMACIA PAMPATAR C.A (FARMACIA PAMPATAR, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1211, 'J294602401', 'CELL CENTER NUMBER ONE, C.A. (REPUESTOS LOFRAN, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1212, 'J314724444', 'ANKUN, C.A. (ANKUN C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1213, 'J301726014', 'TROPICAL MELON C.A (TROPICAL MELON C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1214, 'J310628637', 'GADA FASHION, C.A. (GADA FASHION C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1215, 'J303871224', 'EL SOL DE JUAN GRIEGO IMP C.A. (EL SOL DE JUANGRIEGO IMP., C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1216, 'J065068841', 'XIONI IMPORT, C.A (XIONI IMPORT)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1217, 'J296960518', 'ELECTRA VIDEO, C.A. (ELECTRA VIDEO, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1218, 'J309705288', 'FERRETERIA EL FARO, C.A (FUNDACION DE JORNADAS CIENTIFICAS)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1219, 'J302246652', 'SERVICENTRO DE CAUCHOS MILANO, C.A. (SERVICENTRO DE CAUCHO MILANO)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1220, 'J313025364', 'MULTIBOMBAS D  D, C.A. (MULTIBOMBAS D  D, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1221, 'J311370706', 'SUMISALUD C.A (SUMISALUD. C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1222, 'J296980845', 'LIBRERIA LA REDOMA, C.A. (LIBRERIA LA REDOMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1223, 'J295882114', 'BABY BEDDING, C.A. (BABY BEDDING)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1224, 'V160619348', 'ROSA DEL CARMEN RODRIGUEZ BRAZON', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1225, 'J293986745', '2K COMPUTACION, C.A (2K COMPUTACION, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1226, 'J065103205', 'FRENOS CEDEÑO, C.A. (FRENOS CEDEÑO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1227, 'J293837340', 'BODEGON EL BAJO, C.A (BODEGON EL BAJO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1228, 'J297040650', 'PANADERIA Y PASTELERIA D ANTONIO, C.A (PANADERIA PASTELERIA D ANTONIO)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1229, 'J311230190', 'EXQUISITECES TITA VALLE, C.A. (EXQUISITESES TITA VALLE, C..A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1230, 'J065089458', 'FARMACIA SANTA TERESITA, S.R.L. (FARMACIA SANTA TERESITA, S.R.L. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1231, 'J065090375', 'EL AMANECER, C.A. (EL AMANECER, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1232, 'J311791213', 'INVERSIONES 87-49 C.A. (INVERSIONES 87-49, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1233, 'J311893148', 'MADERERA DEL CARIBE, C.A (MADERERA DEL CARIBE)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1234, 'J314346180', 'CENTRO MEDICO ESTETICO DEL CARIBE C.A. (CENTRO MEDICO ESTETICO DEL CARIBE; C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1235, 'J303955215', 'COMERCIAL COLINAS DE BOQUERON, C.A (COMERCIAL COLINAS DE BOQUERON, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1236, 'J080032292', 'CONSTRUCTORA ROFERCA, C.A. (CONSTRUCTORA ROFERCA, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1237, 'J314733800', 'NUEVO LOOK, C.A. (NUEVO LOOK, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1238, 'J314457837', 'MULTISERVICIOS BRIACOS C.A. (INVERSIONES BRIACOS, CA.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1239, 'V083968792', 'ZURAIMA DEL VALLE RODRIGUEZ DE MARIN     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1240, 'J314713299', 'PLAZA VIDEO, C.A. (PLAZA VIDEO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1241, 'J294282105', 'DISTRIBUIDORA REYMAR N 1, C,A, (DISTRIBUIDORA REYMAR N 1, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1242, 'J296516774', 'MURANO SHOP, C.A. (MURANO SHOP, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1243, 'J296632189', 'CENTRO OPTICO DE MARGARITA, C.A. (CENTRO OPTICO DE MARGARITA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1244, 'J316696715', 'AUTO FRIO 134-A, C.A. (AUTO FRIO 134-A C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1245, 'J308177210', 'CERRAJERIA BOLIVAR C.A (CERRAJERIA BOLIVAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1246, 'J316552853', '\"MUSA ESTILOS,C.A. (MUSA ESTILOS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1247, 'J310093709', 'A1, C.A. (A1. C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1248, 'J065044349', 'LA ATARRAYA DE MARGARITA C A (LA ATARRAYA DE MARGARITA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1249, 'J312131969', 'HOLLYWOOD VIDEO SOMOS EL CINE, C.A. (HOLLYWOOD VIDEOS SOMOS EL CINE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1250, 'J302027012', 'MATERIALES VENCEREMOS CA (MATERIALES VENCEREMOS CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1251, 'J307566671', 'AUTOMOTRIZ GARCIA GONVEIA, C.A (AUTOMOTRIZ GARCIA GONVEIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1252, 'J305901600', 'COMERCIAL LEVIJOSE, S.R.L (COMERCIAL LEVIJOSE, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1253, 'J293667941', 'EL VEGUERO, C.A (EL VEGUERO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1254, 'J065030020', 'IMPORTADORA CLAY C A (IMPORTADORA CLAY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1255, 'J312533501', 'MY COPYAMAR, C.A. (MY COPYAMAR C.A,)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1256, 'J065009772', 'CREACIONES LA RESTINGA C.A. (CREACIONES LA RESTINGA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1257, 'J309138596', 'BAZZI SHOP,C.A. (BAZZI SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1258, 'J305219540', 'REPRESENTACIONES LA ISLA C.A (REPRESENTACIONES LA ISLA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1259, 'J306821147', 'DISTRIBUIDORA PAPELERA GIL, C.A (DISTRIBUIDORA PAPELERA GIL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1260, 'J309767038', 'MARVIN, C.A. (MARVIN, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1261, 'J295711506', 'TITANIC FASHION,C.A. (TITANIC FASHION)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1262, 'J309767097', 'SUCCAR IMPORT, C.A. (SUCCAR IMPORT, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1263, 'J309441027', 'GOODIES C.A. (GOODIES, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1264, 'J065078561', 'DINER S SPORT CA (DINER´S SPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1265, 'J310195773', 'AIREX , C.A (AIREX)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1266, 'J309599402', 'INVERSIONES PAO, C.A. (INVERSIONES PAO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1267, 'V040510326', 'MIRVILIA RAMONA MATA DE LOPEZ\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1268, 'J306857990', 'LA SENSACIONAL C.A (LA SENSACIONAL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1269, 'J080041909', 'FANY C.A (FANY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1270, 'J303924557', 'EST.DE SERV.TERRANOVA C.A (ESTACIÓN DE SERVICIOS TERRANOVA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1271, 'J313628026', 'JACJU INVERSIONES,C.A. (JACJU INVERSIONES )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1272, 'J317073339', 'JACJU INVERSIONES II C.A (LABORATORIOS CALIER, S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1273, 'J294427405', 'CERRAJERIA LA EPIFANIA C.A (CERRAJERIA LA EPIFANIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1274, 'J080044908', 'EL CAÑON DEL PTO LIBRE C A (EL CAÑON DE PUERTO LIBRE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1275, 'J306489088', 'RECTIFICACIONES CARUPANO, C.A. (RECTIFICACIONES CARUPANO)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1276, 'J316386899', 'AUTOLAVADO ARACELIS AUTOLUB, C.A. (AUTOLAVADO ARACELIS AUTOLUB, C.A.   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1277, 'J065030216', 'IMPORTADORA SARA C A ()', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1278, 'J302669146', 'SAI BABA IMPORT C.A. (SAI BABA IMPORT C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1279, 'J295409133', 'MANUEL DE JESUS COVA VALDIVIEZO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1280, 'V093010260', 'ALGENYS EVANGELISTA FARFAN  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1281, 'J310317976', 'COLOMBIANA DE ARCILLAS LA AUTENTICA, C.A. (COLOMBIANA DE ARCILLAS LA AUTENTICA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1282, 'J309140612', 'INVERSIONES WICHO FORO, C.A. (INVERSIONES WICHO FORO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1283, 'J065074990', 'TIGUI TIGUI-SUEO TROPICAL C.A. (EL TIGUI-TIGUI SUEÑOS TROPICAL C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1284, 'J065000082', 'GUAIREN, C.A. (GUAIREN, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1285, 'J303272070', 'SUPER SOUND TWO C.A (SUPER SOUND TWO, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1286, 'J309676245', 'MIDAN SHOP, C.A (MIDAN SHOP C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1287, 'J313243876', 'LA ESQUINA DE ORO, C.A (LA ESQUINA DE ORO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1288, 'J311237224', 'TWISTER C.A (TWISTER C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1289, 'J307481617', 'CENTRO DE ESPECIALIDADES OFTALMOLOGICAS C.A (CENTRO DE ESPECIALIDADES OFTALMOLOGICAS)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1290, 'J300249999', 'PROMOCIONES INTERNACIONALES CA (PROMOCIONES INTERNACIONALES, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1291, 'J311937366', 'OPTICA EL ANGEL, C.A. (OPTICA EL ANGEL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1292, 'J295176937', 'COMERCIAL BILAL, C.A (COMERCIAL BILAL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1293, 'J295143486', 'ALTA VISION,C.A (ALTA VISION,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1294, 'J312016728', 'BODEGON EL TIO C.A (BODEGON EL TIO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1295, 'J310765103', 'HAPPY GYM, C.A. (HAPPY GIM, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1296, 'J312949180', 'K M SPORT C.A. (K M SPORT C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1297, 'J065030372', 'LABORATORIO MEDICO ANALITICO, C.A. (LABORATORIO MEDICO ANALITICO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1298, 'J308608742', 'LA FAROLA, C.A. (LA FAROLA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1299, 'J308781940', 'LA MAJADA BAR RESTAURANT, C.A. (LA MAJADA BAR RESTAURANT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1300, 'J296844003', 'REPUESTOS ELECTRICOS EL PORVENIR, C.A (REPUESTOS ELECTRICOS EL PORVENIR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1301, 'J306967796', 'BODEGON EL BAYONERO, C.A. (BODEGON EL BAYONERO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1302, 'J306224513', 'OPTICA LOS ANGELES CA (OPTICA LOS ANGELES CA   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1303, 'J316613224', 'INVERSIONES CASIQUIARE, C.A (INVERSIONES CASIQUIARE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1304, 'V116865544', 'SIRIA EGLEE (NAIL FAIR ESTETICA) MONTECALVO SEVILLA   \r\n\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1305, 'J309943464', 'COLORISIMA ARAGUA, C.A. (COLORISIMA ARAGUA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1306, 'J300156354', 'COLOR MARACAY C.A. (COLOR MARACAY C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1307, 'V115287571', 'LUISA TERESA VASQUEZ JIMENEZ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1308, 'V149584826', 'DAYANA DESIREE MERMEJO GARCIA\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1309, 'J090010092', 'CONSTRUCCIONES RIEGOS Y ESTUDIOS S. A. (CONSTRUCCIONES RIEGOS Y ESTUDIOS S. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1310, 'J075376528', 'EL MANJAR C A (EL MANJAR C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1311, 'J313286729', 'INVERSIONES ESMERCRI C.A. (INVERSIONES ESMERCRI C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1312, 'J309557394', 'MEGA CAUCHOS POPULAR C.A. (MEGA CAUCHOS POPULAR C.A.     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1313, 'J293859255', 'TIMO CAUCHO, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1314, 'J307247878', '100 % CERAMICA C A (100%CERAMICA,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1315, 'J306435875', 'TORSYS CA (TORSYS CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1316, 'J305491844', 'AUTO LAVADO LOS COLORES, S.R.L (AUTO LAVADO LOS COLORES, S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1317, 'J303101780', 'ORBE INVERSIONES C.A. (ORBE INVERSIONES C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1318, 'J308870803', 'MADERAS DEL CENTRO SANTA RITA, C.A. (MADERAS DEL CENTRO SANTA RITA, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1319, 'J309086022', 'MADERAS DEL NORTE, C.A (MADERAS DEL NORTE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1320, 'J295932103', 'MADERAS DEL CENTRO ZULIA C.A (MADERAS DEL CENTRO ZULIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1321, 'J295919069', 'MADERAS DEL CENTRO OCCIDENTE C.A (MADERAS DE CENTRO OCCIDENTE C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1322, 'J303993648', 'CERAMICAS EL MORRO CA (CERAMICAS EL MORRO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1323, 'J307700114', 'CORPORACION INTEGRAL T.R.O CA (CORPORACION INTEGRAL T.R.O CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1324, 'J313601993', 'DKZL C.A (DKZL C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1325, 'J314212745', 'DON PEPERONE EXPRESS, C.A. (DON PEPERONE EXPRESS, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1326, 'J303967116', 'VALENFRUT CA (VALENFRUT C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1327, 'J307797576', 'MADERAS DEL CENTRO MARACAY, C.A. (MADERAS DEL CENTRO MARACAY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1328, 'J309508938', 'FERRERTERIA POPULAR TUCACAS, C.A. (FERRETERIA POPULAR TUCACAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1329, 'J311505695', 'MATERIALES DONDE TITA C.A. (MATERIALES DONDE TITA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1330, 'J300077381', 'MADERAS DEL CENTRO C A (MADERAS DEL CENTRO C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1331, 'J307159839', 'MADERAS DEL CENTRO NAGUANAGUA C A (MADERAS DEL CENTRO NAGUANAGUA C A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1332, 'J306982680', 'MADERAS DEL CENTRO ALVARADO C A (MADERAS DEL CENTRO ALVARADO C A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1333, 'J310908290', 'MADERAS DEL CENTRO SAN BLAS C.A (MADERAS DEL CENTRO SAN BLAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1334, 'J317134621', 'REPUESTOS TODO BOMBAS, C.A. ()', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1335, 'J304767870', 'REPUESTOS TODO RUSTICO C.A. (REPUESTOS TODO RUSTICO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1336, 'J313139009', 'ESTETICA SANTYS II, C.A. (ESTETICA SANTYS II, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1337, 'J306231889', 'EL GUACARAZO C.A (EL GUACARAZO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1338, 'J301236599', 'MEGA LICORES S A (MEGA LICORES S A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1339, 'J306317236', 'CARNE EN VARA EL PAISA C.A. (EL MIRADOR PAISA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1340, 'J308106216', 'PERFUMERIA METROPOLI SHOP CA (PERFUMERIA METROPOLI SHOP CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1341, 'J311921311', 'CORPORACION RIMO CAUCHOS C.A. (CORPORACION RIMO CAUCHOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1342, 'J300239195', 'MATERIALES H D C A (MATERIALES H D C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1343, 'J075156250', 'LUBRICANTES INDUSTRIALES C A (LUBRICANTES INDUSTRIALES CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1344, 'J316559220', 'LUBRIALCA C.A (LUBRIALCA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1345, 'J314558250', 'INVERSIONES LEACSIRA, C.A. (INVERSIONES LEACSIRA, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1346, 'J309323083', 'PINFERKA, C.A. (PINFERKA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1347, 'J311024123', 'SUMINISTROS MOLA, C.A. (SUMINISTROS MOLA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1348, 'J311797491', 'I.M.D. RECUBRIMIENTOS Y COLORES C.A. (I.M.D. RECUBRIMIENTOS Y COLORES C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1349, 'J316097218', 'TECNO PINTURAS DEL CENTRO C.A. (TECNO PINTURAS DEL CENTRO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1350, 'J304200463', 'CERAMIOFERTA CA (CERAMIOFERTA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1351, 'J303033954', 'MULTISERVICIOS MIGUEL ANGEL C.A. (MULTISERVICIOS MIGUEL ANGEL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1352, 'J297094458', 'FLORISTERIA KIOSKO LARAFLOR, C.A. (FLORISTERIA KIOSKO LARAFLOR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1353, 'J307287292', 'POL TIENDAS CA (POL TIENDAS CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1354, 'J303994750', 'VOLVO PARTS C.A VOLPARCA (VOLVO PARTS CA VOLPARCA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1355, 'J308628000', '\"SIRON DE VENEZUELA, C.A\" (SIRON DE VENEZUELA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1356, 'J294138080', 'JOCYMA, CA. (JOCYMA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1357, 'J309260758', 'RESTAURANTE EL ÑA-ÑA-ÑA, C.A. (RESTAURANTE EL ÑA-ÑA-ÑA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1358, 'J306408568', 'JOYERIA MARA   LAGO MALL CA. (JOYERIA MARA  LAGO MALL CA     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1359, 'J296767203', 'PASTELERIA CAPITAS C.A. (PASTELERIA CAPITAS, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1360, 'J300078361', 'CARTIER SPORT S A (CARTIER SPORT, S.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1361, 'J311482130', 'SUPER ZAPATO GRANDE COMPANIA ANONIMA (SUPER ZAPATO GRANDE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1362, 'J293904641', 'COMERCIAL GENESIS MF,CA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1363, 'J293903793', 'INVERSIONES BOLIVAR,CA (INVERSIONES BOLIVAR,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1364, 'J293904161', 'DISTRIBUIDORA DE MODA,CA (DISTRIBUIDORA DE MODA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1365, 'J294217338', 'INVERSIONES 6979, C.A (INVERSIONES 6979, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1366, 'J293904285', 'INVERSIONES KN 2.021.CA (INVERSIONES KN 2021 C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1367, 'J294216625', 'COMERCIAL LA ESPERANZA, C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1368, 'J293904340', 'INVERSIONES LA OFERTA,CA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1369, 'J293904420', 'COMERCIALIZADORA LA GRANDE,CA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1370, 'J293904501', 'INVERSIONES 958,CA (INVERSIONES 958, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1371, 'J314510878', 'HASBAYA SHOES COMPANIA ANONIMA (HASBAYA SHOES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1372, 'J314198424', 'KAUSAM SHOES,C.A (KAUSAM SHOES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1373, 'J315221845', 'DON BIAGIO MINI MARKET  SUPER EXPRESS,C.A (DON BIAGIO MINI-MARKET  SUPER EXPRESS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1374, 'J296381844', 'JE INVERSIONES, C.A. (LAS CANCHITAS) (JE INVERSIONES, C.A. (LAS CANCHITAS))', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1375, 'J293904323', 'COMERCIAL GILLE,CA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1376, 'J316010287', 'COMERCIAL RAYAN,C.A. (COMERCIAL RAYAN, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1377, 'J316010309', 'DISTRIBUIDORA RAGED,C.A. (DISTRIBUIDORA RAGED, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1378, 'J293903912', 'DISTRIBUIDORA BASAM,CA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1379, 'J307576812', 'PANADERIA Y CHARCUTERIA 72, C.A (PANADERIA Y CHARCUTERIA 72, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1380, 'J303754120', 'FULL HOUSE, C.A (FULL HOUSE, C.A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1381, 'J294184073', '\"INVERSIONES SENSATION, C.A. \" (LA TORE DEL CABALLERO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1382, 'J294079954', 'INVERSIONES MULTIPLES LISMAR COMPAÑIA ANONIMA(INMULICA) (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1383, 'J303835376', 'FERRALFA, C.A. (QWERTYU)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1384, 'J314136313', 'JOYERIA DORADO. C.A. (JOYERIA DORADO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1385, 'J306691197', 'JOYERIA MIRNA, C.A. (JOYERIA MIRNA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1386, 'J309875531', 'JOYERIA ORO FINO, C.A. (JOYERIA ORO FINO)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1387, 'J309401734', 'VOICE COM, C.A. (WERTYU)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1388, 'J313129283', 'ICONOGRAPH SOLUCIONES INTEGRALES,C.A. (ICONOGRAPH SOLUCIONES INTEGRALES,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1389, 'J307688505', 'MERCANTIL ALFREDO C.A. (MERCANTIL ALFREDO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1390, 'J306193677', 'QUERUBINES CA. (KERUBINES C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1391, 'J293721458', 'QUERUBINES TEEN C.A (QUERUBINES TEEN C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1392, 'J300317145', 'GRANZONERA LA MILAGROSA,C.A.(GRALMICA) (GRANZONERA LA MILAGROSA,C.A.(GRALMICA)    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1393, 'J314117041', 'TOTALPET, COMPANIA ANONIMA (TOTALPET,CA) (TOTALPET C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1394, 'J309484729', 'JOYAS Y RELOJES SAMARA COMPANIA ANONIMA (Z', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1395, 'J296784647', 'VIVERES KATERIN COMPAÑIA ANONIMA (VIVERES KATERIN C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1396, 'J070116897', 'FARMACIA ZULIMAR CA (FARMACIA ZULYMAR C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1397, 'J312262770', 'ARCO IRIS CENTER C.A. (ARCO IRIS CENTER C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1398, 'V160745726', 'YENNIFER JOSEFINA CASTILLO MARCANO    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1399, 'J296114765', 'AREPERA RESTAURANT EL VIEJO CRIOLLO C.A (AREPERA RESTAURANT EL VIEJO CRIOLLO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1400, 'J304048491', 'NOVEDADES EL CRIOLLO C.A. (NOVEDADES EL CRIOLLO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1401, 'V064366749', 'MARIA MAQUENA JARDIN DE DA MATA\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1402, 'V133831890', 'CHAO ZHENG HUI ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1403, 'J307005858', 'EL CHINO IMPORTACIONES CA (EL CHINO IMPORTACIONES CA     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1404, 'J314223623', 'HAMBURGUESAS CIUDAD VICTORIA C.A. (HAMBURGUESAS CIUDAD VICTORIA, C.A.  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1405, 'J295978863', 'DELI PORKYS, C.A (DELI PORKYS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1406, 'J302690366', 'MECANICA Y ELECTRO AUTO LA PAZ S.R.L (MECANICA Y ELECTROAUTO LA PAZ SRL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1407, 'E811920048', 'JOSE MARIA DE GOUVEIA    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1408, 'V161447362', 'JUAN MANUEL MORALES SARMIENTO\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1409, 'V025081591', 'MERCEDES AMELIA BASTIDAS DE MACHADO   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1410, 'J295849206', 'INVERSIONES SWAIDA, C.A (INVERSIONES SWAIDA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1411, 'V089985109', 'GUSTAVO ENRIQUE VELASQUEZ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1412, 'V110905471', 'ELY TERESA CASTILLO GARI ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1413, 'V087879492', 'CARLA IVON PIMENTEL DE CARRILLO\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1414, 'J301604881', 'BODEGA LA MIRANDINA C.A (BODEGA LA MIRANDINA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1415, 'V098885699', 'JOSE ANGEL PELLICANE BONNANO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1416, 'V146373999', 'NELLYS MARIA LAMEDA RAMIREZ ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1417, 'J309024710', 'UPA CHAMOS  S.R.L. (UPA CHAMOS S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1418, 'J294611281', 'AUTOLAVADO LA BURBUJA C.A (HIDROMATICOS MILLAN, S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1419, 'J316031853', 'ANDROMEDA C.A. (ANDROMEDA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1420, 'V106716443', 'MANUEL JOSE DA COSTA MEDINA ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1421, 'J295233302', 'CENTRO PROFESIONAL DE ESTETICA UNIVERSO DE LUZ SPA CA (CENTRO PROFESIONAL DE ESTETICA UNIVERSO DE LU', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1422, 'V107538590', 'FRANK REINALDO GARCIA FRANCO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1423, 'J307598166', 'INVERSIONES LA ECONOMICA C.A (INVERSIONES LA ECONOMICA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1424, 'J313691380', 'MATERIALES DE TAPICERIA\"ROLO LLANO,C.A.\" (MATERIALES DE TAPICERIA \"ROLO LLANO, C.A.\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1425, 'J296552770', 'RELOLANDIA,C.A (RELOLANDIA,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1426, 'V062528903', 'MANUEL DACOSTA DACOSTA   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1427, 'J310235295', 'DISTRIBUIDORA ALMAR CA (DISTRIBUIDORA ALMAR C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1428, 'V128428166', 'LUIS EDUARDO PAEZ GOMEZ  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1429, 'V051569020', 'EFRAIN ALFREDO PEREZ ESCOBAR', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1430, 'J075172833', 'BAZAR PANADERIA EL CRIOLLO,C.A. (BAZAR PANADERIA EL CRIOLLO C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1431, 'V170633012', 'CESAR ENRIQUE SILVA GUTIERREZ\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1432, 'V111202563', 'YAHILIN EGLEDT FERNANDEZ MANZANO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1433, 'J300443752', 'CEGILU C.A (CEGILU CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1434, 'J293897718', 'SOCIEDAD EN NOMBRE COLECTIVO GAMARRA (SOCIEDAD EN NOMBRE COLECTIVO GAMARRA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1435, 'V025077276', 'LUCILA BOLIVAR DE BARRIOS', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1436, 'J304136862', 'FARMACIA HOSPITAL CA (FARMACIA HOSPITAL C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1437, 'J296347093', 'LIBRERIA CRISTIANA UNA ESPERANZA VIVA S.A (LIBRERIA CRISTIANA UNA ESPERANZA VIVA S.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1438, 'J295318685', 'VARIEDADES LOS ARCANGELES Y ALGO MAS, C.A (VARIEDADES LOS ARCANGELES Y ALGO MAS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1439, 'J296945926', 'FERREVARIEDADES SAN BENITO, C.A (FERREVARIEDADES SAN BENITO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1440, 'J311873899', 'JADE ACCESORIOS, COMPANIA ANONIMA (JADE ACCESORIOS, COMPANIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1441, 'J070286997', 'NUEVA HOLLIWOOD SALON PARA CABALLEROS, S R L (NUEVA HOLLIWOOD SALON PARA CABALLERO S R L)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1442, 'J315232324', 'INVERSIONES GONZALEZ RINCON, C.A (INVERSIONES G  R, C.A) (ELIZABETH ALTA PELUQUERIA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1443, 'J070111720', 'MULTITIENDA EL VINEDO,CA (MULTIENDA EL VIÑEDO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1444, 'J294327702', '\"LE BAGAGE ELITÉ, C.A.\" (\"LE BAGAGE ELITÉ, C.A.\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1445, 'J309696963', 'SWISS TIME ACCESORIOS CA (SWISS TIME ACCESORIOS CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1446, 'J301040627', 'LICORES SETENTA Y OCHO,CA (LICORES SETENTA Y OCHO,CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1447, 'J307783699', 'BODEGON VERITAS, C.A. (BODEGON VERITAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1448, 'J301688538', 'LICORERIA VIENTO NORTE C A ()', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1449, 'J294420311', 'DELICIA DE CREMA, C.A (DELICIA DE CREMA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1450, 'J306477055', 'NIVILATTO C.A (NIVILATTO, C,A,)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1451, 'J315858525', 'DISTRIBUIDORA TONY,C.A. (DISTRIBUIDORA TONY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1452, 'J295961510', 'CAMPAMENTO INAWAJA, C.A. (CAMPAMENTO INAWAJA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1453, 'J070446013', 'LICORES LA CORONA S R L (LIMORCA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1454, 'J070552042', 'JOYERIA IMPERIAL C A (JOYERIA IMPERIAL C A    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1455, 'J311359206', 'GLAMOUR BOUTIQUE, C.A (GLAMOUR BOUTIQUE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1456, 'J295994710', 'INVERSIONES ZARA COMPAÑIA ANONIMA (INVERSIONES SARA COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1457, 'J296833478', 'DETALLES GABECA, COMPAÑIA ANONIMA (DETALLES GABECA,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1458, 'J301145577', 'JOYERIA BALLY C A (JOYERIA BALLY C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1459, 'J313706116', 'AREPAS Y PARRILAS SANTA MARIA CA (AREPAS Y PARRILLAS SANTA MARIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1460, 'J302776465', 'LICORES 76 CA (LIMORCA   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1461, 'J303325653', 'DEPOSITO LOS FERNANDEZ CA (DEPOSITO LOS FERNANDEZ CA     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1462, 'J070509856', 'NILUZ S A (NILUZ S A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1463, 'J313630349', 'ELIZABETH ALTA PELUQUERIA CA (ELIZABETH ALTA PELUQUERIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1464, 'J307816120', 'LUZ MARINA CENTRO DE DEPILACION,ESTETICA Y BELLEZA CA (OIUYT)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1465, 'J311122915', 'SALON DE BELLEZA LA CHIC UNISEX, C.A. (AS)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1466, 'J296406634', 'INVERSIONES SANCHEZ ACUÑA,CA (INVERSIONES SANCHEZ ACUÑA,CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1467, 'J308808008', 'SECRETOS, COMPAÑIA ANONIMA (SECRETOS,COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1468, 'J312189770', 'COMERCIAL LAGOCHI, C.A (COMERCIAL LAGOCHI, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1469, 'J312257920', 'SALON DE BELLEZA Y BARBERIA JAKSON STIL,C.A (SALON DE BELLEZA Y BARBERIA JAKSON STIL, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1470, 'J302693527', 'DEPOSITO MAKPATO, C.A (DEPOSITO MAKPATO, C.A   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1471, 'J296679240', 'JOSE MARIA STYLE CENTER, COMPAÑIA ANONIMA (JOSE MARIA STYLE CENTER, COMPAÑIA ANONIMA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1472, 'J302196400', 'EL BODEGON DEL PASTOR. C.A (EL BODEGON DEL PASTOR. C.A    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1473, 'J295056788', 'CASANOVA MARTINEZ, BIANEY DE LA CRUZ-FIRMA UNIPERSONAL (ESTUDIO DE BELLEZA CASANOVA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1474, 'J295170939', 'ATUENDOS,CA (ATUENDOS,CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1475, 'J316400689', 'MIA FASHION, C.A (\" MIA FASHION, C.A\"     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1476, 'J294296432', 'EL RINCON DE LOS SANTOS C.A (GRAFICA MODERNA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1477, 'V152861911', 'VANESSA ANDREINA MORANTES ARAUJO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1478, 'J296730431', 'INVERSIONES RENO,CA (INVERSIONES RENO,CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1479, 'J303606300', 'NILDA AÑEZ ESTETICA, C.A. (NILDA AÑEZ ESTETICA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1480, 'J293768438', 'DANIELITA BOUTIQUE C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1481, 'J312427841', 'YAL-LA RESTAURANT, C.A. (YAL-LA RESTAURANT, C.A.   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1482, 'J307517069', 'CALIFORNIA SHOP, C.A. (CALIFORNIA SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1483, 'J294833519', 'CALZADOS LA PLAZA SHOES, C. A. (CALZADOS LA PLAZA SHOES, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1484, 'J070398388', 'EL GIGANTE DEL SAN C A (EL GIGANTE DEL SAN, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1485, 'J293716870', 'COMERCIAL KAZY REGALAO, C.A (COMERCIAL KAZY REGALAO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1486, 'J312550287', 'SANTA EDUVIGES IMPORT  EXPORT, C.A (SANTA EDUVIGES IMPORT  EXPORT CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1487, 'J313607045', 'KORAZONADAS LAGO, C.A (DD)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1488, 'J303300677', 'PANADERIA PASTELERIA Y LUNCHERIA LA QUINTA AVENIDA,C.A. (PANADERIA PASTELERIA Y LUNCHERIA LA QUINTA ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1489, 'J316515044', 'CHIQUITITAS, C.A (CHIQUITITAS, C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1490, 'J310501009', 'MUNDO DE FANTASIA C.A. (DD)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1491, 'J294398871', 'ABASTOS SANTA ANA, C.A. (ABASTOS SANTA ANA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1492, 'J296640696', 'EMPANADAS EL PABELLON, C.A. (EPACA) (EMPANADAS EL PABELLON, C.A. (EPACA))', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1493, 'J308976652', 'KORAZONADAS C.A. (KORAZONADAS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1494, 'J294664946', 'INVERSIONES BRACHO BRICEÑO,C.A. (HH CONSULTORES GERENCIALES C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1495, 'J312995548', 'PALMIRA S G COMPANIA ANONIMA (PALMIRA S G COMPANIA ANONIMA  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1496, 'J312550317', 'GABY SPORTS, C.A (GABY SPORTS,CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1497, 'J311569944', 'INVERSIONES EL REY DEL JEAN,COMPANIA ANONIMA (INVERSIONES EL REY DEL JEAN CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1498, 'J314958895', 'COMERCIALIZADORA DE FLORISTERIA Y ART. NAVIDEÑOS MR. CHRISTMAS, C.A. (COMERCIALIZADORA DE FLORISTERI', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1499, 'J311638555', 'GANDINI CHINITA,COMPANIA ANONIMA (GANFINI CHINITA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1500, 'J313584576', 'REPRESENTACIONES JOSE DIAZ, C. A ( JODICA ) (REPRESENTACIONES JOSE DIAZ, C. A ( JODICA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1501, 'E820962349', 'TING FONG LEE  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1502, 'J294250297', 'PERCALTEX, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1503, 'J300101053', 'BAR RESTAURANT MAGNIFICENT CHINA S R L (BAR RESTAURANT MAGNIFICENT CHINA S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1504, 'J309949748', 'SKIN CARE CA (SKIN CARE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1505, 'J311522603', 'INVERSIONES Y CONSTRUCCIONES N  B,C.A. (INVERSIONES Y CONSTRUCCIONES N  B. C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1506, 'J294125603', 'EL RINCON DE LAS OFERTAS C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1507, 'J070243279', 'TIO PEPE S R L (AS)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1508, 'J312691794', 'RESTAURANT POPULAR, C.A (RESTAURANT POPULAR C.A,)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1509, 'J311003215', 'REPUESTOS GABRIEL ALFONSO, C.A (REPUESTOS GABRIEL ALFONSO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1510, 'J296619131', 'RESTAURANT NUEVO AVILA, C.A. (RESTAURANT NUEVO AVILA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1511, 'V016550058', 'JOSE ANTONIO FERNADEZ PEREZ ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1512, 'J313702056', 'REPUESTOS CASA VIEJA, CA (WW)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1513, 'J295676794', 'OPAL DISTRIBUCIONES, COMPAÑIA ANÓNIMA (OPAL DISTRIBUCIONES, COMPAÑIA ANÓNIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1514, 'J304859465', 'CHIQUITOS Y GRANDES DEL SUR C.A (CHIQUITOS Y GRANDES DEL SUR C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1515, 'J307774584', 'DISTRIBUIDORA SHALOM C.A (DISTRUBIDORA SHALOM C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1516, 'J313949426', 'COOPERATIVA MANSERCA 32165 (COOPERATIVA MANSERCA 32165)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1517, 'J294367585', 'AUTO REPUESTOS NERIO, C.A. (AUTO REPUESTOS NERIO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1518, 'J315079224', 'BOUTIQUE WOMAN FASHION C.A (BOUTIQUE WOMAN FASHION C.A    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1519, 'J303308597', 'MARYLAND CLUB PIANO BAR RESTAURANT,CA (MARYLAND CLUB PIANO BAR RESTAURANT,CA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1520, 'J295505671', 'CALZADOS PIKACHU, C.A. (CALZADOS PICACHU, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1521, 'J296634254', 'SIBERIAN PLUS, C.A. (SIBERIAN PLUS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1522, 'J313881511', 'SIBERIAN,COMPANIA ANONIMA (SIBERIAN C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1523, 'J295650337', 'EL EMPORIO DEL ESTILISTA,C.A (EL EMPORIO DEL ESTILISTA,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1524, 'J314615009', 'VARIEDADES JOSE  ZULMY, COMPANIA ANONIMA (VAJOZUCA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1525, 'J293686881', 'SIBERIAN SHOES , C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1526, 'J316032752', 'QUE BELLAS, C.A (QUE BELLAS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1527, 'J314927892', 'RESTAURANTE DONA PEPA C.A (RESTAURANRTE DOÑA PEPA,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1528, 'J293579457', 'MILAGUE IMAGEN INTEGRAL DORAL, CA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1529, 'J311168800', 'RUEDAS EXTREMAS, COMPANIA ANONIMA (RUEDAS EXTREMAS, COMPANIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1530, 'J296357200', 'PARENTEXIS, C.A. (PARENTEXIS.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1531, 'J314416782', 'LIBRERIA Y VARIEDADES PITOKITO COMPANIA ANONIMA (LIBRERIA Y VARIEDADES PITOKITO COMPANIA ANONIMA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1532, 'J311001727', 'ENCANTOS PARA MI FIESTA, CA (ENCANTOS PARA MI FIESTA, CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1533, 'J302799023', 'CLICK SUPER HOTEL,C.A. (CLICK SUPER HOTEL,C.A.     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1534, 'J310056889', 'FRIGORIFICO DE CARNES DEL REYNO, C.A. (FRIGORIFICO DE CARNES DEL REYNO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1535, 'J070391235', 'BOUTIQUE MODAS CLUB, C.A. (BOUTIQUE MODAS CLUB, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1536, 'J295519028', 'DON ZAPATO, CA (DON ZAPATO )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1537, 'J308814172', 'ADORNOS Y VARIEDADES LIMA, COMPANIA ANONIMA (ADORNOS Y VARIEDADES LIMA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1538, 'J296494363', 'KID´S PLACE, C.A. (KID´S PLACE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1539, 'J303461050', 'FERRETERIA Y CONSTRUCCIONES LA COROMOTO,COMPANIA ANONIMA (FERRETERIA Y CONSTRUCCIONES LA COROMOTO, C', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1540, 'J316127419', 'DINO SPORT, C.A. (DINI SPORT C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1541, 'V118658880', 'MAYBE ALICIA DIAZ MERCHAN', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1542, 'J315131005', 'INVERSIONES A  P, C.A. (INVERSIONES A  P, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1543, 'J311063862', 'HOT LINE, COMPANIA ANONIMA (HOT LINE, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1544, 'J305735700', 'TASCA AVENTURA C.A (TASCA AVENTURA,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1545, 'J314053183', 'CABELOS,C.A. (CABELOS , C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1546, 'J306914234', 'AUTANA C.A (NAILS CARE CENTER)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1547, 'J312067616', '\"REJAS DE PERU RESTAURANT,C.A.\" (REJAS DE PERU RESTAURANT, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1548, 'J296400059', 'INVERSIONES LA JAULA, C.A. (INVERJACA) (INVERSIONES LA JAULA, C.A. (INVERJACA))', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1549, 'J293533244', 'INVERSIONES RICARDO, CA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1550, 'J312130172', 'SUPER REPUESTOS YASMIN,C.A. (SUPER REPUESTOS YASMIN C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1551, 'J293713021', 'FRUTTO GELATTO, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1552, 'J295505957', 'PIES DESCALZO, C. A. (PIES DESCALZO, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1553, 'J316127370', 'PEDRO SHOES, C.A. (PEDRO SHOES C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1554, 'J307868430', 'HI - HI SHOP, C.A (QW)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1555, 'J070230010', 'REPUESTOS Y LUBRICANTES EL BRILLANTE, C.A (REPUESTOS Y LUBRICANTES EL BRILLANTE,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1556, 'J307340630', '\"FERRE MATERIALES DEL SUR, COMPAÑIA ANONIMA\" (\"FERRE MATERIALES DEL SUR, COMPAÑIA ANONIMA\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1557, 'J309863037', 'COMERCIAL ANTHUAN, C.A. (COMERCIAL ANTHUAN, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1558, 'J070081732', 'RESTAURANT PALACE C A (RESTAURANT PALACE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1559, 'J308217662', 'INTEL COMPUTACION,COMPAÑIA ANONIMA (INTEL COMPUTACION,COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1560, 'J070477334', 'FABRICA DE CALZADOS RONY SHOES CA (FABRICA DE CALZADOS RONY SHOES CA   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1561, 'J293808952', 'INTERCITY MARACAIBO, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1562, 'J295019483', 'INVERSIONES CELLULAR ZONE C.A (INVERSIONES CELLULAR ZONE C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1563, 'J314060015', 'SERMAR DISTRIBUCIONES C.A (1)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1564, 'J070553430', 'LA ESTEFANIA II DELICIAS NORTE C A (LA ESTEFANIA 2 DELICIAS NORTE C,A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1565, 'J312726881', 'SUPER PANADERIA VIRGEN DE COROMOTO,C.A. (SUPER)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17');
INSERT INTO `sisg_finalsclients` (`id`, `rif`, `description`, `name`, `lastName`, `phone`, `email`, `fiscalAddress`, `enable`, `creation_date`) VALUES
(1566, 'J314280538', 'MELANY INFANTIL C.A (MELANY INFANTIL C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1567, 'J306093630', 'VARIEDADES DENCIS C.A (VARIEDADES DENCIS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1568, 'J312787813', 'FERRETERIA LOLA , C.A (FERRETERIA LOLA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1569, 'J095056465', 'TASCA RESTAURANT FUENTE DE SODA CASA BLANCA,C.A (NIGHT CLUB FUENTE DE SODA CASA BLANCA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1570, 'E843437144', 'MARIA MAGDALENA OROZCO CACERES\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1571, 'E822444817', 'YUANHUAN ZHENG ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1572, 'J311378200', '\"RUEDAS ITALVEN,C.A\" (RUEDAS ITALVEN, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1573, 'J305067201', 'GRAN PAPEL BOLIVAR CA (GRAN PAPEL BOLIVAR CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1574, 'V016358041', 'EDICTA CECILIA RODRIGUEZ CUBA\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1575, 'J315248069', 'FRIGORIFICO LA CAMPIÑA, C.A. (FRIGORIFICO LA CAMPIÑA, C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1576, 'J294960170', 'CATHERINE ATELIER, C.A (CATHERINE ATELIER, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1577, 'J294013880', 'LISTO PARA LLEVAR, C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1578, 'J304762534', 'AUTO ACCESORIOS HERMANOS NICHOLZON, C.A. (AUTO ACCESORIOS HERMANOS NICHOLZON, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1579, 'J309524240', 'TELEMARKETING COMUNICACIONES, C.A. (TELEMARKETING COMUNICACIONES C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1580, 'J312368934', 'FABRICA DE HIELO LA COROBA CA (\"FABRICA DE HIELO LA COROBA, C.A.\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1581, 'V060699360', 'MARIA DEL CARMEN PEREZ DE AZOCAR', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1582, 'J313456250', 'RALPH SPORT, C.A (RALPH SPORT, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1583, 'J311378197', 'SALOCTEC C.A (SALOCTEC C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1584, 'V069319072', 'EVELYN JOSEFINA PEÑA RIVAS  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1585, 'J300840190', 'CERAMICAS GUANIPA CA (CERAMICAS GUANIPA C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1586, 'J305960429', 'GRUPO EMPRESARIAL CORREA CA (GRUPO EMPRESARIAL CORREA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1587, 'J306955739', 'M.A.D. SUMINISTROS Y SERVICIOS, C.A. (M.A.D. SUMINISTROS Y SERVICIOS,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1588, 'V089423330', 'TERESA DE JESUS FEBRES ZAMBRANO\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1589, 'J309282476', '\"MULTISERVICIOS EL PIONERO, COMPAÑIA ANONIMA\" (\"MULTISERVICIOS EL PIONERO, COMPAÑIA ANONIMA\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1590, 'J294359809', 'BODEGON EL \"CATAMARAN\", C.A. (BODEGON EL \"CATAMARAN\", C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1591, 'V030234339', 'VILMA ISABEL AFANADOR GUTIERREZ\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1592, 'V017559555', 'JOSE FELIX ALESSIO TOVAR ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1593, 'J316540405', 'CAUCHOS BOLIVAR, C.A. (CAUCHOS BOLIVAR,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1594, 'J311973230', 'DETALLES FERLA C.A (DETALLES FERLA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1595, 'J308567078', '\"SERVICENTRO EL PORVENIR, COMPAÑIA ANÓNIMA\" (\"SERVICENTRO EL PORVENIR, COMPAÑIA ANÓNIMA\" )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1596, 'J308639850', 'SEMICEL CELULAR 2001 CA (SEMICEL CELULAR 2001 CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1597, 'J293528526', 'ADMINISTRADORA 1983, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1598, 'J316930807', 'INVERSIONES HONEY POP, C.A. (INVERSIONES HONEY POP,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1599, 'J305205710', 'INVERSIONES SAN JENG C.A (INVERSIONES SAN JENG C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1600, 'J308658103', 'COMERCIAL BIGCEL C.A. (COMERCIAL BIGCEL C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1601, 'V080031897', 'CARLOS ALBERTO QUINTERO RIVAS\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1602, 'V027043042', 'MARIA ROSA MENDEZ DE USECHE ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1603, 'J295412568', 'ASOCIACION COOPERATIVA MI  KASA . (ASOCIACION COOPERATIVA MI  KASA .)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1604, 'J309301233', 'SERVICE COPY,C A (SERVICE COPY,C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1605, 'J305021929', 'TJ-IMPORT CA (SIN)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1606, 'J303110460', 'ZAPATERIA LA CENICIENTA, CA (ZAPATERIA LA CENICIENTA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1607, 'V130977673', 'HECTOR JOSE VOLCAN MOLINA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1608, 'J314408046', 'FRIGORIFICO EL CASTILLO C A (FRIGORIFICO EL CASTILLO C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1609, 'V114665408', 'ANA CECILIA DAVILA GUILLEN  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1610, 'V080805566', 'JOSE ARIALDO REY HERNANDEZ  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1611, 'V022875627', 'MARIA DEL CARMEN ZAMBRANO VERDY\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1612, 'V080849660', 'CARMEN MILAGRO ESCALANTE ZAMBRANO     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1613, 'J303685307', 'DISTRIBUIDORA AURORA, C.A (DISTRIBUIDORA AURORA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1614, 'J317036816', 'MIAMI GRAN CAFE C.A (MIAMI GRAN CAFE C.A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1615, 'J317036921', 'PANADERIA MIAMI C.A (PANADERIA MIAMI C.A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1616, 'V006483360', 'SAUL ORESTE CARDENAS LARES  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1617, 'J295113048', 'REPUESTOS SURBASAN C.A (REPUESTOS SURBASAN C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1618, 'J307295384', 'MOVILDENX C.A. (MOVILDENX C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1619, 'J306076573', 'NET-SOFTWARE CENTRO DE SERVICIO, CA (NET-SOFTWARE CENTRO DE SERVICIOS, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1620, 'J308596361', 'SERVIMATICA C A (SEVIMATICA  C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1621, 'J314542419', 'TELECOMUNICACIONES LA QUINTA, CA (TELECOMUNICACIONES LA QUINTA, CA    )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1622, 'J314016652', 'RESTAURANT MR RICO COMPAÑIA ANONIMA (RESTAURANT MR RICO COMPAñIA ANONIMA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1623, 'V052197003', 'GLADIS HORTENSIA RODRIGUEZ HERNANDEZ     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1624, 'J295317581', 'REPRESENTACIONES SARA,C.A (REPRESENTACIONES SARA ,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1625, 'J307341149', 'CORPORACION BIMPLAZA C.A. (CORPORACION BIMPLAZA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1626, 'J293896452', 'DIGI TAREK, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1627, 'J310221898', 'COMERCIAL TAREK, C.A (COMERCIAL TAREK, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1628, 'J307705370', 'WINNER, C.A. (WINNER, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1629, 'J313731269', 'CONEXION PLAZA, C.A. (CONEXION PLAZA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1630, 'J315534517', 'BEBE FASHION C.A. (BEBE FASHION C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1631, 'J307150912', 'QUE GOLILLA, C A (QUE GOLILLA, C A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1632, 'J315202476', 'DECO PINTURAS EL ROSARIO, C.A. (DECO PINTURAS EL ROSARIO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1633, 'J314204556', 'MARMOLES CASA ROK, C.A. (MARMOLES CASA ROK, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1634, 'J080262387', 'FARMACIA SAN ANTONIO C.A. (FARMACIA SAN ANTONIO C.A.     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1635, 'J295976771', 'CENTRO DE CONEXIONES BULEVARD C.A (CENTRO DE CONEXIONES BULEVARD C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1636, 'J315037505', 'NANA SPORT 2000, C.A (NANA SPORT 2000, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1637, 'J293939240', 'NASER CELL, C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1638, 'J306643478', 'CENTRO INTEGRAL NUEVA ERA, C A (CENTRO INTEGRAL NUEVA ERA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1639, 'J314104675', 'RUMBA ELECTRONICA, CA (\" RUMBA ELECTRONICA, C.A \")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1640, 'J294340539', '\"PINTURAS JAVIDAIM,C.A\" (\"PINTURAS JAVIDAIM,C.A\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1641, 'J310390169', 'ZAPATERIA CARACAS, C.A (ZAPATERIA CARACAS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1642, 'J300882888', 'EL PALACIO DEL CALZADO C A (EL CALZADO DEL CALZADO, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1643, 'J303481957', 'GINA IMPORT, C.A. (GINA IMPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1644, 'J295925131', 'NATY CALLING DIGITAL, C.A. (NATY CALLING DIGITAL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1645, 'J315111497', 'GRUPO LAMDA NYSE, C.A. (GRUPO LAMDA NYSE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1646, 'J309614240', 'AUTOLAVADO Y ACCESORIOS LA GOTA, C.A (AUTOLAVADO LA GOTA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1647, 'J294125239', 'CONTU SALUD, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1648, 'V168842828', 'JORGE LUIS RODRIGUEZ GONZALEZ\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1649, 'J303605893', 'SPIVA, C.A (SPIVA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1650, 'J305416036', 'SAN COCHO RESTAURANTE TIPICO, CA (SAN COCHO RESTAURANTE TIPICO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1651, 'J305165670', 'FARMACIA EMPRESARIAL C A (FARMACIA EMPRESARIAL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1652, 'J090002103', 'DISTRIBUIDORA MANABEL C A (DISTRIBUIDORA MANABEL C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1653, 'J311964878', 'REPUESTOS AMERICANOS LA 15, CA (REPUESTOS AMERICANOS LA 15, CA )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1654, 'J306263543', 'AUTOPERIQUITOS Y CAUCHOS LAMO COMPAÑÍA ANONIMA (AUTO PERIQUITOS LAMO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1655, 'J306150986', 'DISTRIBUIDORA DE CAUCHOS 2000 CA (DISTRIBUIDORA DE CAUCHOS 2000 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1656, 'V055225873', 'EVELYN COROMOTO ESCAURIZA   STRAUSS   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1657, 'J307723360', 'NEW FASHION CA (NEW FASHION CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1658, 'J311538410', 'CLOTHING SHOP, CA (CLOTHING SHOP C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1659, 'V115028010', 'CARHEL ANDREINA CONTRERAS SANCHEZ     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1660, 'J302912563', 'ZAPATERIA ORQUIDEA CA (ZAPATERIA ORQUIDEA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1661, 'J070050748', 'FOTO ESTUDIO VENEZUELA C A (FOTO ESTUDIO VENEZUELA C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1662, 'V080749976', 'TIBISAY COROMOTO CADENAS MEZA\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1663, 'V116374052', 'JULLY JOSEFINA ANGULO ROJAS ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1664, 'J294868541', 'ORGANIZACION MORA EVENTOS C.A (ORGANIZACION MORA EVENTOS C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1665, 'J296522685', 'AZALEA ACCESORIOS C.A. (AZALEA ACCESORIOS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1666, 'V054486584', 'MARIA VIRGINIA ROJAS DE FIGUEREDO     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1667, 'J090332472', 'CAFETIN Y HELADERIA LOS ANDES S R L (CAFETIN Y HELADERIA LOS ANDES S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1668, 'V044859641', 'MARIA DE LOS ANGELES ALBARRAN CASTILLO   ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1669, 'V080463061', 'LEANIRY GABRIELA BLANCO MARQUINA', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1670, 'V080037070', 'SERGIO ALEXANDER GUILLEN ROJAS\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1671, 'V058495693', 'MARCELO SEGUNDO BENITEZ MARQUEZ\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1672, 'V156407131', 'DOUGLAS ALEXANDER DELGADO SALAS\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1673, 'J313789607', 'NOVEDADES MARCERIU C.A (NOVEDADES MARCERIU C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1674, 'J090367438', 'AUTO REPUESTOS DUBAL, C.A (AUTO REPUESTOS DUBAL, C.A     )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1675, 'J300805174', 'AGROLAGO, SA (AGROLAGO, SA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1676, 'J303628567', 'PINTURAS MUNDO MAGICO EJIDO CA (PINTURAS MUNDO MAGICO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1677, 'V122206579', 'NENA MARILU ROJAS GUILLEN', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1678, 'J308638889', 'TIENDAS SULY C A (TIENDAS SULY C A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1679, 'J307021667', '\"CERAMIUNO, C.A\" (CERAMIUNO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1680, 'J300681130', 'FERRETERIA LA LUCHA C A (FERRETERIA LA LUCHA C A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1681, 'J310412189', 'TELECOMUNICACIONES SAINT TROPEZ, CA (TELECOMUNICACIONES SAINT TROPEZ, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1682, 'J303124968', 'CLUB PRIVADO LA ESTILLERA AC (DEBE ACTUALIZAR SU NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1683, 'V065084852', 'ZULY MARTINA MASS \r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1684, 'V034420510', 'AQUILES RAFAEL MACUARE MACUARE\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1685, 'V030321347', 'HERNAN JOSE QUINTERO MORENO ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1686, 'E818190495', 'SARA YANETH RODRIGUEZ RODRIGUEZ\r', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1687, 'J090358196', 'CASA NATURISTA PROMOTORA ANDINA DE COMERCIO C.A. (PROMOTORA ANDINA DE COMERCIO C.A  )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1688, 'J301401387', 'INVERSIONES TOYO - ANDES, CA (INVERSIONES TOYO - ANDES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1689, 'V114679425', 'ALEXANDER ANGULO ARISMENDI  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1690, 'V034145918', 'LUIS AREVALO BELANDRIA PEREIRA\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1691, 'J311288066', '\"EL BAÑO BARATO, C.A\" (\"EL BAÑO BARATO, C.A\" )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1692, 'J294768768', 'PANADERIA Y PASTELERIA MICO PAN C.A. (PANADERIA Y PASTELERIA MICO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1693, 'V080739598', 'DOMINGO RAMIREZ CASTILLO ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1694, 'J309560530', 'ESTOCOLMO C.A (ESTOCOLMO C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1695, 'J302010578', 'SUPER ELEGANCIA S R L (DEBE ACTUALIZAR NOMBRE COMERCIAL )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1696, 'J302010551', 'SUPER ROCKY SPORT S.R.L. (DEBE ACTUALIZAR NOMBRE COMERCIAL )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1697, 'J309241273', 'LA MONTANA DE LOS SUENOS CA (DEBE ACTUALIZAR SU RIF)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1698, 'J090358935', 'ALEXIS Y LA VENEZUELA DE ANTIER C A (ALEXIS Y LA VENEZUELA DE ANTIER C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1699, 'J090244883', 'PUEBLO MUSEO LOS ALEROS C A (DEBE ACTUALIZAR )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1700, 'J304462778', 'REST.EL FRAILEJON 5 C.A (\"RESTAURANT EL FRAILEJON 5, C.A\")', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1701, 'J296764328', 'BIJOUX PLAZA, C. A. (BIJOUX PLAZA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1702, 'V114661631', 'FAVIO JOSE ANGULO GAMEZ  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1703, 'V248806008', 'ROBERTO MEDAU  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1704, 'J303834310', 'MUSIKANDO, C.A (MUSIKANDO, C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1705, 'J090085017', 'INVERSIONES MARCUZZI C A (INVERSIONES MARCUZZI C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1706, 'J313556564', 'MR.FRANELAS C A (MR. FRANELAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1707, 'J313178020', 'INVERSIONES 6063 C.A. (INVERSIONES 6063 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1708, 'J306143564', 'VESTIMENTA CA (VESTIMENTA CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1709, 'J302597820', 'GATICA BOUTIQUE C.A (GATICA BOUTIQUE C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1710, 'V042841710', 'GLADYS ELIZABETH MORENO TRUJILLO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1711, 'J090104216', 'SERVICIOS GERENCIALES ANDINOS C A (SERVICIOS GERENCIALES ANDINOS C A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1712, 'J314644033', 'VALERIA BOUTIQUE, COMPAÑIA ANONIMA (VALERIA BOUTIQUE, COMPAÑIA ANONIMA   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1713, 'J313643572', 'CERAMICAS EBANO COMPAÑIA ANONIMA (CERAMICAS EBANO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1714, 'J293778352', 'COLOR´S STYLE, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1715, 'J296764468', 'MAGIC FACTORY, C. A. (MAGIC FACTORY)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1716, 'J090021965', 'CONCRETERA TABAY CA (CONCRETERA  TABAY  C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1717, 'J309130013', '\"CREACIONES EL PATIQUIN C.A  \" (\"CREACIONES EL PATIQUIN C.A  \"   )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1718, 'J306227733', 'EXSTASIS SHOP, C.A (EXSTASIS SHOP C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1719, 'J090097554', 'MERIDA IMPORT CAUCHOS C A (MERIDA IMPORT CAUCHO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1720, 'J315322439', 'SECVICIO AUTOMOTRIZ D Y M C.A (SERVICIO AUTOMOTRIZ D Y M C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1721, 'V080093205', 'FERMAN ANGULO  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1722, 'J310113041', 'KASABURGUER,C.A (KASABURGUER, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1723, 'J314153226', 'PASARELA S C.A. (PASARELA`S C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1724, 'J313835668', 'TODO HOGAR, CA (TODO HOGAR, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1725, 'J306264108', 'HIDROMAN 1 SRL (HIDRO MAN 1 SRL )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1726, 'E815978350', 'RAFAEL VILLAR RAMETTA    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1727, 'V080456367', 'JORGE ORLANDO UZCATEGUI SALAS\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1728, 'J307671041', 'PROYECCIONES CINEMAX CA (PROYECCIONES CINEMAX CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1729, 'J295319614', 'INVERSIONES CINE 2021  C,A (INVERSIONES CINE 2021 C,A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1730, 'V114656050', 'MARGUALIDA GRISEL OTAIZA GUTIERREZ    ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1731, 'J090107398', 'HIMOCA (HIELOS MORA C.A ) (HIELOS MORA C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1732, 'J305290997', 'EDCAR COMPAÑIA ANONIMA (EDCAR,C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1733, 'V015266879', 'JUAN DE DIOS MEDINA TORRIJOS', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1734, 'V093958515', 'JESUS ERNESTO TEBENIN VARGAS', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1735, 'J312521783', 'VARIEDADES CATENA, CA (VARIEDADES CATENA, CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1736, 'J090075119', 'MOTORES PARTES CA (MOPARCA) (MOTORES PARTES CA (MOPARCA))', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1737, 'V056805245', 'JAIME EVENCIO SANCHEZ CHAUSTRE\r\n', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1738, 'V126552595', 'RAMON ANTONIO SOTO QUINTERO ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1739, 'V101088304', 'MIGUEL ANGEL VALERO UZCATEGUI\r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1740, 'V025546411', 'DORY MIREYA DE LA CHIQUIN CASTRO MEDINA   \r\n ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1741, 'V061072507', 'ALBERTO SALVADOR MACHADO ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1742, 'J293649943', 'MULTISERVICIOS Y SILENCIADORES GIANFRANCO C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1743, 'V037668148', 'ELY ISABEL ARELLANO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1744, 'J304044623', 'FARMACIA GALENO, CA (FARMACIA GALENO, COMPAÑIA ANÓNIMA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1745, 'J306736506', 'ADORNOTELAS CA (ADORNOTELAS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1746, 'J294003729', 'FARMACIA GALERA C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1747, 'V044918001', 'MARIA ALBERTINA UZCATEGUI DE SANCHEZ     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1748, 'J310250391', 'INTURIPREDESPACHO, CA (INTURIPREDESPACHO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1749, 'V034971273', 'MAGALY JOSEFINA SALAS DE ROSALES', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1750, 'V041486348', 'MARITZA DEL CARMEN NAVA DE ARAQUE     ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1751, 'V164439638', 'ERYMAY YOANA PEÑA DELGADO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1752, 'J090232770', 'SUPERMERCADO CENTENARIO C.A (SUPERMECADO CENTENARIO C.A )', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1753, 'J294566693', 'COQUETICOS, C.A (COQUETICOS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1754, 'V090836281', 'CARMEN OMAIRA RAMIREZ DE DELGADO', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1755, 'V136485110', 'ARGENIS ANTONIO LOBO VIVAS  ', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1756, 'J301411099', 'DACO CA (DACO CA)', NULL, NULL, NULL, NULL, NULL, 1, '2020-03-06 14:15:17'),
(1757, 'J312171197', 'Bits Americas SAS CA ', NULL, NULL, NULL, NULL, '', 1, '2020-04-08 16:23:29'),
(1758, 'J315009480', 'J.C. NETWORKS, C.A ', NULL, NULL, NULL, NULL, '', 1, '2020-04-13 16:39:25'),
(1759, 'J293987130', 'IMPRESORAS FISCALES 421 CA ', NULL, NULL, NULL, NULL, '', 1, '2020-04-14 00:17:21'),
(1760, 'J000263493', 'S.A. NACIONAL FARMACEUTICA (SANFAR) (S.A. NACIONAL FARMACEUTICA ', NULL, NULL, NULL, NULL, '', 1, '2020-04-16 14:09:56'),
(1761, 'V138880636', 'SKARLET MARINA ALVARADO CEDILLO', NULL, NULL, NULL, NULL, '', 1, '2020-04-17 12:37:05');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_finalsclientsusers`
--

CREATE TABLE `sisg_finalsclientsusers` (
  `id` int(11) NOT NULL,
  `finalsclientsId` int(11) NOT NULL,
  `userId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_fiscalsoperations`
--

CREATE TABLE `sisg_fiscalsoperations` (
  `id` int(11) NOT NULL,
  `fiscalOperation` varchar(50) COLLATE utf32_spanish_ci NOT NULL,
  `fiscalMode` varchar(50) COLLATE utf32_spanish_ci NOT NULL,
  `providerId` int(11) NOT NULL,
  `distributorId` int(11) NOT NULL,
  `technicianId` int(11) NOT NULL,
  `finalClientId` int(11) NOT NULL,
  `serial` varchar(13) COLLATE utf32_spanish_ci NOT NULL,
  `initSeal` varchar(11) COLLATE utf32_spanish_ci NOT NULL,
  `finalSeal` varchar(11) COLLATE utf32_spanish_ci NOT NULL,
  `fiscalAddress` varchar(150) COLLATE utf32_spanish_ci NOT NULL,
  `fiscalResult` tinyint(1) NOT NULL,
  `serialRetative` varchar(13) COLLATE utf32_spanish_ci NOT NULL,
  `codeOperation` varchar(9) COLLATE utf32_spanish_ci NOT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_spanish_ci;

--
-- Volcado de datos para la tabla `sisg_fiscalsoperations`
--

INSERT INTO `sisg_fiscalsoperations` (`id`, `fiscalOperation`, `fiscalMode`, `providerId`, `distributorId`, `technicianId`, `finalClientId`, `serial`, `initSeal`, `finalSeal`, `fiscalAddress`, `fiscalResult`, `serialRetative`, `codeOperation`, `creation_date`) VALUES
(6, 'FISCALIZACION', 'AUXILIAR', 1, 18, 2, 6, 'Z1B8051655', 'Q2323', 'J8970', 'Calle Luna Calle Sol', 0, '', '070432357', '2020-03-31 17:40:01'),
(7, 'FISCALIZACION', 'AUXILIAR', 1, 18, 2, 6, 'Z1B8051656', 'A2323', 'B8973', 'Calle Luna Calle Sol', 0, '', '019136997', '2020-03-31 17:40:30'),
(14, 'FISCALIZACION', 'AUXILIAR', 1, 7, 2, 8, 'Z1B1234567', 'Q2344', 'J8910', 'Calle Luna Calle Sol', 1, '', '077464548', '2020-04-01 14:16:15'),
(15, 'DESBLOQUEO', 'AUXILIAR', 1, 7, 2, 8, 'Z1B1234567', '1234', '7654', 'Calle Luna Calle Sol', 1, '', '244869004', '2020-04-01 16:01:02'),
(16, 'CAMBIO MEFIS', 'REMOTO', 1, 7, 2, 8, 'F01F7FA49A7', '000', '000', '', 1, 'Z1B1234567', '', '2020-04-01 16:33:46'),
(20, 'FISCALIZACION', 'AUXILIAR', 1, 7, 2, 8, 'Z1B1234567', 'Q2344', 'J8910', 'Calle Luna Calle Sol', 0, '', '077464548', '2020-04-13 22:35:26'),
(33, 'FISCALIZACION', 'REMOTO', 1, 2, 11, 1758, 'Z1B8532223', 'DA123', '2324', 'Domicilio fiscal actual', 1, '', '767273444', '2020-04-07 00:10:19'),
(35, 'CAMBIO MEFIS', 'AUXILIAR', 1, 2, 11, 1758, 'F0112345ABD', '000', '000', '', 0, 'Z1B8532223', '', '2020-04-14 00:34:13'),
(36, 'FISCALIZACION', 'AUXILIAR', 1, 2, 11, 1758, 'Z1B8532223', 'DA123', '8878', 'Domicilio fiscal actual', 0, '', '685235684', '2020-04-14 00:34:33'),
(37, 'DESBLOQUEO', 'AUXILIAR', 1, 2, 11, 1758, 'Z1B8532223', 'E344', '2233', 'Domicilio fiscal actual', 0, '', '483911052', '2020-04-14 00:35:35'),
(38, 'FISCALIZACION', 'AUXILIAR', 1, 2, 11, 1760, 'Z1B8887777', '34344', '55553', 'Domicilio fiscal actual', 0, '', '832408548', '2020-04-16 14:12:36'),
(39, 'FISCALIZACION', 'AUXILIAR', 2, 2, 2, 1761, 'DLA7000001', 'DA123', '4443', 'Domicilio fiscal actual', 1, '', '799345636', '2020-04-15 13:04:18'),
(40, 'DESBLOQUEO', 'AUXILIAR', 1, 2, 11, 1758, 'Z1B8532223', '3323', '21212', 'Calle Maria Luna', 0, '', '767879564', '2020-04-21 10:00:29'),
(41, 'DESBLOQUEO', 'AUXILIAR', 2, 25, 11, 1761, 'DLA7998899', 'DDSDS', 'DFDFD', 'Callejon Gutierrez Edificio Rivaz,piso 2', 0, '', '846724492', '2020-04-21 11:14:45'),
(42, 'DESBLOQUEO', 'AUXILIAR', 1, 2, 11, 1758, 'Z1B8532223', 'DA123', '445554444', 'Domicilio fiscal actual', 0, '', '311675276', '2020-04-30 17:24:04'),
(43, 'DESBLOQUEO', 'AUXILIAR', 1, 2, 11, 1758, 'Z1B8532223', 'DA123', '4443', 'Domicilio fiscal actual', 0, '', '766538124', '2020-05-14 13:39:11'),
(44, 'DESBLOQUEO', 'AUXILIAR', 2, 1, 2, 44, 'DLA7234449', 'EWTET', 'YRYY', ' CALLE LOPEZ AVELEDO C/C CUARTA TRANSVERSAL QTA JAMBAL NRO 1 URB CALICANTO MARACAY ARAGUA ZONA POSTAL 2102  24/10/2022', 0, '', '498740876', '2020-07-16 19:10:05');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_marks`
--

CREATE TABLE `sisg_marks` (
  `id` int(11) NOT NULL,
  `name` varchar(150) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_marks`
--

INSERT INTO `sisg_marks` (`id`, `name`, `creation_date`) VALUES
(0, 'VARIAS', '2020-02-28 16:01:40'),
(1, 'ACLAS', '2019-10-08 11:32:22'),
(2, 'BIXOLON', '2019-10-08 11:32:22'),
(3, 'CASIO', '2019-10-08 11:32:22'),
(4, 'CUSTOM', '2019-10-08 11:32:22'),
(5, 'GENERICO', '2019-10-08 11:32:22'),
(6, 'OKI', '2019-10-08 11:32:22'),
(7, 'STAR', '2019-10-08 11:32:22'),
(8, 'UNIWELL', '2019-10-08 11:32:22'),
(9, 'RIVAO', '2019-10-08 11:32:22'),
(10, 'Generac', '2019-10-08 11:32:22'),
(11, 'Imobile', '2019-10-08 11:32:22'),
(13, 'DASCOM', '2019-10-08 11:32:22'),
(14, 'HKA', '2019-10-08 11:32:22'),
(15, 'PANTUM', '2019-10-08 11:32:22'),
(17, 'MARK', '2019-10-08 14:55:51');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_menus`
--

CREATE TABLE `sisg_menus` (
  `id` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  `parentId` int(10) NOT NULL,
  `view` varchar(45) NOT NULL,
  `level` int(1) NOT NULL,
  `order` int(2) NOT NULL,
  `url` varchar(100) NOT NULL,
  `visible` tinyint(1) NOT NULL,
  `path_icon` varchar(100) DEFAULT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_menus`
--

INSERT INTO `sisg_menus` (`id`, `name`, `parentId`, `view`, `level`, `order`, `url`, `visible`, `path_icon`, `creation_date`) VALUES
(1, 'Productos', 0, '/', 1, 3, '#', 1, '', '2019-10-10 14:22:04'),
(2, 'Modelos', 1, 'Index', 2, 3, 'Model/', 1, 'Image/category.ico', '2019-10-10 14:27:00'),
(3, 'Marcas', 1, 'Index', 2, 2, 'Mark/', 1, 'Image/replacement/.ico', '2019-10-10 14:23:45'),
(4, 'Clientes', 0, '/', 1, 2, '#', 1, NULL, '2019-05-03 17:45:47'),
(5, 'Proveedores', 4, 'Index', 2, 1, 'Provider/', 1, 'Image/supplier.ico', '2019-05-27 10:00:04'),
(6, 'Distribuidores', 4, 'Index', 2, 2, 'Distributor/', 1, 'Image/distributor.ico', '2019-06-07 16:15:35'),
(7, 'Casas de Software', 4, 'Index', 2, 4, 'DeveloperClient/', 1, 'Image/develoment.ico', '2019-07-25 17:36:45'),
(8, 'Técnicos de Clientes', 4, 'Index', 2, 3, 'Technician/', 1, 'Image/technicians.ico', '2019-06-26 15:00:58'),
(9, 'Empleados', 0, '/', 1, 1, '#', 1, '', '2019-08-22 14:11:34'),
(10, 'Colaboradores', 9, 'Index', 2, 1, 'Employee/', 1, 'Image/employees.ico', '2019-08-22 14:12:37'),
(11, 'Manejo de Cuentas', 0, '/', 1, 0, '#', 1, NULL, '2019-05-03 17:45:47'),
(12, 'Roles', 11, 'Index', 2, 1, 'Rol/', 1, 'Image/roles.ico', '2019-05-03 17:45:47'),
(13, 'Usuarios', 11, 'Index', 2, 2, 'User/', 1, 'Imagen/users.ico', '2019-05-03 17:45:47'),
(14, 'Menus', 11, 'Index', 2, 3, 'Menu/', 1, 'Image/menus.ico', '2019-05-06 14:30:23'),
(15, 'Categorias', 1, 'Index', 1, 1, 'Category/', 1, 'Image/imbl.ico', '2019-10-10 14:23:11'),
(16, 'Perfiles', 0, '/', 1, 4, '#', 1, '', '2019-06-18 13:34:31'),
(17, 'Personal', 16, '/Index', 2, 1, 'Distributor/', 1, 'Image/nomina.ico', '2019-06-18 13:39:14'),
(18, 'Técnicos', 16, '/Index', 2, 2, 'Technician/', 1, 'Image/tecnical.ico', '2019-06-25 11:02:02'),
(19, 'Desarrollador', 16, 'Index/', 2, 1, 'DeveloperClient/', 1, '', '2019-07-30 10:40:39'),
(20, 'Clientes Finales', 4, 'Index/', 2, 5, 'FinalClient/', 1, '', '2019-08-05 10:49:46'),
(21, 'Datos y Grupo', 16, 'Index', 2, 3, 'Employee/', 1, '', '2019-08-23 10:59:29'),
(22, 'Departamentos', 9, 'Index', 2, 2, 'Departament/', 1, '', '2019-08-26 11:30:32'),
(23, 'Cargos', 9, 'Index', 2, 3, 'Chargue/', 1, '', '2019-08-26 11:31:01'),
(24, 'Accesorios', 1, 'Index', 2, 4, 'Accessory/', 1, '', '2019-10-25 15:18:22'),
(25, 'Repuestos', 1, 'Index', 2, 5, 'Replacement/', 1, 'Image/replacement.png', '2020-01-27 10:07:39'),
(26, 'Productos Terminados', 1, 'Index', 2, 6, 'Product/', 1, '', '2020-02-13 10:02:04'),
(27, 'Prefijos', 1, 'Index', 2, 7, 'Prefix/', 1, '', '2020-02-18 19:04:21'),
(28, 'Operaciones', 0, '/', 1, 4, '#', 1, '', '2020-03-24 15:23:16'),
(29, 'Seriales Productos', 28, 'Index', 2, 1, 'SerialProduct/', 1, '', '2020-03-24 15:24:40'),
(30, 'Seriales Repuestos', 28, 'Index', 2, 2, 'SerialReplacement/', 1, '', '2020-03-24 17:42:02'),
(31, 'Enajenaciones', 28, 'Index', 2, 3, 'Alienation/', 1, '', '2020-04-07 17:22:50'),
(32, 'Operaciones Fiscales', 28, 'Index', 2, 4, 'FiscalOperation/', 1, '', '2020-04-13 11:14:12'),
(33, 'Intervenciones Tecnicas', 28, 'Index', 2, 5, 'TechnicalOperation/', 1, '', '2020-04-28 12:22:57'),
(34, 'Consolidacion XML', 28, 'Index', 2, 6, 'Consolidation/', 1, '', '2020-04-28 12:24:04'),
(35, 'Registros de Eventos', 28, 'Index', 2, 7, 'Activity/', 1, '', '2020-06-08 13:59:48'),
(36, 'Taller de Equipo', 0, '/', 1, 5, '#', 1, '', '2020-08-21 15:55:46'),
(37, 'Ordenes de Servicio', 36, 'Index', 2, 1, 'Workshop/', 1, '', '2020-08-21 15:56:40'),
(38, 'Ordenes en Cola', 36, 'RowOrders', 2, 2, 'Workshop', 1, '', '2020-09-25 14:27:50'),
(39, 'Asignación de Ordenes', 36, 'AssignOrders', 2, 3, 'Workshop', 1, '', '2020-10-09 14:51:49');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_models`
--

CREATE TABLE `sisg_models` (
  `id` int(11) NOT NULL,
  `markId` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_models`
--

INSERT INTO `sisg_models` (`id`, `markId`, `name`, `creation_date`) VALUES
(0, 0, 'GENERICO', '2020-09-21 14:04:17'),
(1, 2, 'SRP-350', '2019-10-17 11:24:16'),
(2, 2, 'SRP-270', '2019-10-17 11:24:38'),
(3, 1, 'CR2300', '2019-10-17 11:28:25'),
(4, 13, 'TD-1140', '2019-10-18 16:10:24'),
(5, 7, 'HSP-7000', '2020-02-18 17:42:02'),
(6, 2, 'SRP-350-IFA', '2020-02-20 11:57:05'),
(7, 10, 'PLANTA-52', '2020-02-20 16:10:48'),
(8, 4, 'KUBE', '2020-03-09 15:35:39'),
(9, 1, 'PP9', '2020-04-02 18:20:47'),
(10, 1, 'LS21530EC', '2020-04-02 18:24:14'),
(11, 1, 'CRD-81FJ', '2020-04-02 18:25:16'),
(12, 2, 'SRP-812', '2020-05-08 10:07:04'),
(13, 14, 'HKA-112', '2020-06-09 14:05:19'),
(14, 8, 'NX-5400', '2020-06-09 14:21:52');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_photographsorder`
--

CREATE TABLE `sisg_photographsorder` (
  `id` int(11) NOT NULL,
  `orderId` int(11) NOT NULL,
  `imageUrl` varchar(150) NOT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_photographsorder`
--

INSERT INTO `sisg_photographsorder` (`id`, `orderId`, `imageUrl`, `creation_date`) VALUES
(1, 2, 'carcase.png', '2020-08-28 11:55:44'),
(2, 1, '162Ftssd.jpeg', '2020-08-28 11:56:09'),
(3, 8, 'Business Model Canvas.jpg', '2020-09-15 13:32:23'),
(4, 18, 'IMG_20170304_131605.jpg', '2020-09-22 10:25:07');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_prefixes`
--

CREATE TABLE `sisg_prefixes` (
  `id` int(11) NOT NULL,
  `initCorrelative` varchar(4) COLLATE utf8_spanish_ci NOT NULL,
  `initAlphaNum` varchar(4) COLLATE utf8_spanish_ci NOT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `sisg_prefixes`
--

INSERT INTO `sisg_prefixes` (`id`, `initCorrelative`, `initAlphaNum`, `creation_date`) VALUES
(0, '000', 'NONE', '2020-02-20 16:40:26'),
(1, '800', 'Z1B', '2020-02-18 16:00:31'),
(2, 'F01', 'F01', '2020-02-18 16:00:31'),
(3, '700', 'DLA', '2020-02-18 00:00:00'),
(4, 'F12', 'F12', '2020-02-18 00:00:00'),
(5, '9009', 'Z1D', '2020-02-20 11:58:28'),
(6, 'F11', 'F11', '2020-02-18 00:00:00'),
(7, '146', 'ZPA', '2020-02-18 00:00:00'),
(8, '170', 'ZZG', '2020-02-18 00:00:00'),
(9, '210', 'Z1A', '2020-02-18 00:00:00'),
(10, 'F02', 'F02', '2020-03-19 00:00:00'),
(11, '1100', 'Z1F', '2020-05-08 10:08:20'),
(12, '999', 'Z7A', '2020-06-09 14:07:18'),
(13, '420', 'Z2A', '2020-06-09 14:22:24');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_products`
--

CREATE TABLE `sisg_products` (
  `id` int(11) NOT NULL,
  `prefixId` int(11) DEFAULT '0',
  `categoryId` int(11) NOT NULL,
  `modelId` int(11) NOT NULL,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(150) DEFAULT NULL,
  `code` varchar(45) NOT NULL,
  `state` tinyint(1) NOT NULL,
  `imageUrl` varchar(150) DEFAULT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `sisg_products`
--

INSERT INTO `sisg_products` (`id`, `prefixId`, `categoryId`, `modelId`, `name`, `description`, `code`, `state`, `imageUrl`, `creation_date`) VALUES
(0, 0, 4, 0, 'Producto Generico', 'Representa un Equipo Generico', 'PT00000', 1, NULL, '2020-09-21 13:06:23'),
(1, 1, 1, 1, 'Impresora Fiscal Termica', 'Impresor Fiscal para imprimir en papel térmico con Memoria Auditoria interna y prerto USB 2.0', 'PT1001', 1, 'SRP-350.jpg', '2020-04-02 18:08:51'),
(2, 9, 1, 2, 'Impresora Fiscal Matrix de Cinta', 'Impresora con Cinta y matrix de puntos con doble rollo', 'PT1002', 1, 'SRP-270.jpg', '2020-04-02 18:09:34'),
(3, 8, 3, 3, 'Caja Registradora con Memoria Auditoria', 'Caja con un solo Rollo y una Memoria de Auditoria de 2 Mega', 'PT3001', 1, 'CR-2300.jpg', '2020-04-02 18:10:20'),
(4, 7, 1, 5, 'Impresora Chequera', 'Impresor Fiscal con Auditoria MEM con Consignación para chequera', 'PT7654', 1, 'HSP-7000.jpg', '2020-04-02 18:10:52'),
(5, 5, 2, 6, 'Impresora Fiscal de Apuesta', 'Impresor Fiscal para emitir ticket de lotería nacional', 'IMPFISAP', 1, NULL, '2020-02-20 11:58:49'),
(6, 0, 5, 7, 'Planta Eléctrica de Gas', 'A base de gas ecológico 110V 5 A', 'G655555', 0, NULL, '2020-02-20 16:11:46'),
(7, 3, 1, 8, 'Impresora Fiscal Térmica', 'Impresor Fiscal de papel térmico', 'PT09080', 1, NULL, '2020-03-19 13:43:28'),
(8, 11, 1, 12, 'Impresora Fiscal Nueva Generacion', 'Incluye ISmart', 'PT84300', 1, NULL, '2020-05-08 10:11:08'),
(9, 12, 1, 13, 'IMPRESORA FISCAL HKA 112', 'Permite la impresión de documentos a través del manejo del panel de control', 'PT6543', 1, 'HKA-112.jpg', '2020-06-09 14:18:14'),
(11, 13, 3, 14, 'Caja Registradora Tradicional', 'Conexión en red RS-485 hasta 32 cajas registradoras. Distribuidores y Centros de servicio técnico a nivel nacional.', 'PT7687', 1, 'NX-5400.jpg', '2020-06-09 14:28:06');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_productsaccessories`
--

CREATE TABLE `sisg_productsaccessories` (
  `id` int(11) NOT NULL,
  `productId` int(11) NOT NULL,
  `accessoryId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `sisg_productsaccessories`
--

INSERT INTO `sisg_productsaccessories` (`id`, `productId`, `accessoryId`) VALUES
(3, 1, 1),
(1, 1, 2),
(7, 2, 5),
(6, 3, 2),
(8, 3, 4),
(5, 3, 7);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_productsreplacements`
--

CREATE TABLE `sisg_productsreplacements` (
  `id` int(11) NOT NULL,
  `productId` int(11) NOT NULL,
  `replacementId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `sisg_productsreplacements`
--

INSERT INTO `sisg_productsreplacements` (`id`, `productId`, `replacementId`) VALUES
(1, 1, 1),
(2, 1, 5),
(5, 1, 7),
(6, 2, 4),
(9, 2, 5),
(3, 3, 1),
(8, 3, 2),
(4, 3, 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_profiles`
--

CREATE TABLE `sisg_profiles` (
  `id` int(11) NOT NULL,
  `name` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `sisg_profiles`
--

INSERT INTO `sisg_profiles` (`id`, `name`, `description`, `creation_date`) VALUES
(1, 'Empleado Administrador', 'Empleado administrador del Sistema', '2019-04-08 12:08:34'),
(2, 'Empleado Supervisor', 'Empleado gerencial con personal a cargo', '2019-04-08 12:08:34'),
(3, 'Empleado Operativo', 'Empleado que ejecuta una función a cargo', '2019-04-08 12:08:34'),
(4, 'Cliente Principal', 'Cliente distribuidor que administra su cuenta y sus relaciones con tecnicos.', '2019-04-08 12:08:34'),
(5, 'Cliente Dependiente', 'Cliente que edepende de una relación de un cliente principal.', '2019-04-08 12:08:34'),
(6, 'Cliente Integrador', 'CLiente que hace la intgegración de un sistema con un producto.', '2019-04-08 12:08:34'),
(7, 'Cliente Mixto', 'Cliente principal e integrador a la vez.', '2019-04-08 12:08:34'),
(8, 'Cliente Final', 'Cliente final usuario de una maquina fiscal.', '2019-04-08 12:08:34');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_providers`
--

CREATE TABLE `sisg_providers` (
  `id` int(11) NOT NULL,
  `rif` varchar(15) NOT NULL,
  `description` varchar(100) NOT NULL,
  `address` varchar(100) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `image` varchar(100) NOT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_providers`
--

INSERT INTO `sisg_providers` (`id`, `rif`, `description`, `address`, `phone`, `email`, `image`, `creation_date`) VALUES
(1, 'J312171197', 'Bits Americas SAS C.A', 'Calle Callej?n Guti?rrez, Edf. Riva, Local 2-1. Planta Baja. La california Norte. Caracas ? Venezuel', '582122020811', 'contacto@bitsamericas.com', 'LogoTFHKA.jpg', '2020-04-02 17:08:48'),
(2, 'J293987130', 'Impresoras Fiscales 421 C.A', 'La California Norte, Av. Fco. Miranda, Torre Profesional La California, piso 9.', '582122354145', 'contac@impresoras421.com', 'LogoIF421.jpg', '2020-04-02 17:08:58'),
(3, 'J402385358', 'HKA Venezuela', 'Callejon Gutierrez', '02122428877', 'hka@hka.com', 'HKAVE.png', '2020-04-02 17:08:04');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_replacements`
--

CREATE TABLE `sisg_replacements` (
  `id` int(11) NOT NULL,
  `prefixId` int(11) DEFAULT '0',
  `modelId` int(11) NOT NULL,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(150) DEFAULT NULL,
  `code` varchar(45) DEFAULT NULL,
  `parts` varchar(45) NOT NULL,
  `state` tinyint(1) NOT NULL,
  `imageUrl` varchar(150) DEFAULT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `sisg_replacements`
--

INSERT INTO `sisg_replacements` (`id`, `prefixId`, `modelId`, `name`, `description`, `code`, `parts`, `state`, `imageUrl`, `creation_date`) VALUES
(0, 0, 0, 'Repuesto Gnerico', 'Repuesto comun', 'R00000', '00000000', 1, NULL, '2020-09-22 09:53:35'),
(1, 0, 3, 'Cable de Bateria', 'Cable a base de esmalte de goma y cobre de vinolo', 'CABCATCRD81F', '12121X00065', 1, 'DSC_0196\'editada.jpg', '2020-04-02 18:20:00'),
(2, 0, 3, 'Cable Plano de Impresores', NULL, 'CABBXXCRI81F', 'MU-000045', 1, NULL, '2020-02-18 17:38:32'),
(3, 0, 3, 'Anillo Tornillo Fiscal ', '81F -FJ/ 68AF -FJ', 'CABBXXCRD83G', 'S/P', 0, NULL, '2020-02-18 17:38:37'),
(4, 0, 2, 'Motor de Avance Cinta y Cabezal', 'Elemento a base de electro magnetigmo de 5V', 'CABCATCRD74F', 'MY000098', 0, NULL, '2020-02-18 17:38:40'),
(5, 0, 2, 'Motor de Avance de Papel', NULL, 'CABBXXCRI32F', 'M20033332', 1, 'img/motor_32.jpeg', '2020-02-18 17:38:44'),
(6, 0, 4, 'Selenoide ', 'Sensor para gaveta', 'CABBXXCRD00G', '120L', 1, NULL, '2020-02-18 17:38:51'),
(7, 0, 1, 'Tarjeta de Alimentación', 'Dispositivo de fuente de poder de + 5 VDC', 'T5544442', '12121X00033', 1, NULL, '2020-02-18 17:38:47'),
(8, 0, 4, 'Unidad Auditora', 'Sesión encargada de controlar la MEUA', '11188', 'UNG5552', 1, NULL, '2020-02-18 17:40:36'),
(9, 2, 1, 'Memoria Fiscal MXF-SERIAL', 'Memoria Fiscal de 4 GB', 'M541211', 'M8787877333', 1, NULL, '2020-02-18 18:13:44'),
(10, 6, 5, 'Memoria Fiscal GANESHA', 'Memoria de 4GB con protección', 'MXF-STAR-PT', 'M8787877355', 1, NULL, '2020-02-20 11:53:22'),
(11, 0, 5, 'Cabezar de Impresor Termico', 'Estructura a base de carbono.', 'BC6553', 'BCNG5521', 1, NULL, '2020-02-20 17:11:34'),
(12, 0, 0, 'Tornillo de 4 mm', 'Tornillo para chasis y placa de piso.', 'T000004', 'N.A', 1, NULL, '2020-02-28 16:09:20'),
(13, 10, 8, 'Memoria Fiscal KUBE', 'Memoria de 8 GB', 'MK8889', 'M8787877344', 1, NULL, '2020-03-19 14:28:11'),
(14, 0, 3, 'Batería de Carbón', 'Batería de 12 VDC 3 Amp', 'BT38989233', 'BT-12M2-3AC', 1, 'DSC_018editada.jpg', '2020-04-02 18:17:43'),
(15, 0, 9, 'Tarjeta Principal PP9', 'Tarjeta de control principal', 'DCS0294', '12121X00332', 1, 'DSC_0294\'editada.jpg', '2020-04-02 18:29:13'),
(16, 0, 12, 'Cabezar  812', 'Cabezar de impresion', '323433', '12121X000444', 1, 'DSC_0138cabezal.jpg', '2020-06-12 14:19:25'),
(17, 0, 12, 'Conector J362 812', 'Conecor de tarjeta', '43434', 'M8787877344', 1, 'DSC_0151coector812.jpg', '2020-06-12 14:23:13');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_replacementsopetechs`
--

CREATE TABLE `sisg_replacementsopetechs` (
  `id` int(11) NOT NULL,
  `operationTechId` int(11) NOT NULL,
  `replacementId` int(11) NOT NULL,
  `serial` varchar(13) DEFAULT NULL,
  `date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_replacementsopetechs`
--

INSERT INTO `sisg_replacementsopetechs` (`id`, `operationTechId`, `replacementId`, `serial`, `date`) VALUES
(1, 16, 9, 'F02A8100DC7', '2020-06-17 17:42:35'),
(2, 17, 10, 'F05E8D00F45', '2020-06-17 18:07:46');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_replacementsorders`
--

CREATE TABLE `sisg_replacementsorders` (
  `id` int(11) NOT NULL,
  `orderId` int(11) NOT NULL,
  `replacementId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_roles`
--

CREATE TABLE `sisg_roles` (
  `id` int(20) NOT NULL,
  `accessId` int(20) NOT NULL,
  `profileId` int(11) NOT NULL,
  `description` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `sisg_roles`
--

INSERT INTO `sisg_roles` (`id`, `accessId`, `profileId`, `description`, `creation_date`) VALUES
(1, 1, 1, 'Super Administrador', '2019-04-30 11:18:00'),
(2, 2, 2, 'Gerente de Servicios', '2019-04-26 16:45:28'),
(3, 5, 2, 'Supervisor Técnico', '2019-07-03 12:17:46'),
(4, 3, 2, 'Gerente Tecnologico', '2019-07-03 12:18:03'),
(5, 4, 3, 'Analista Técnico', '2019-07-03 12:18:27'),
(6, 5, 3, 'Analista Administrativo', '2019-07-03 12:19:45'),
(7, 3, 2, 'Gerente Administrativo', '2019-07-03 12:20:04'),
(8, 6, 3, 'Técnico de Taller', '2019-07-03 12:21:38'),
(9, 5, 3, 'Cliente Centro de Servicios', '2019-04-26 16:45:41'),
(10, 5, 5, 'Tecnico Centro de Servicios', '2019-04-30 11:35:41'),
(11, 5, 6, 'Programador Casa de Software', '2019-04-08 12:04:42'),
(12, 10, 8, 'Rol por Defecto', '2020-03-19 12:01:49');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_rolesmenus`
--

CREATE TABLE `sisg_rolesmenus` (
  `id` int(11) NOT NULL,
  `MenuId` int(10) NOT NULL,
  `RolId` int(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_rolesmenus`
--

INSERT INTO `sisg_rolesmenus` (`id`, `MenuId`, `RolId`) VALUES
(2, 1, 1),
(15, 1, 2),
(33, 1, 4),
(3, 2, 1),
(16, 2, 2),
(26, 2, 4),
(4, 3, 1),
(17, 3, 2),
(5, 4, 1),
(18, 4, 2),
(32, 4, 4),
(6, 5, 1),
(19, 5, 2),
(7, 6, 1),
(20, 6, 2),
(31, 6, 4),
(8, 7, 1),
(21, 7, 2),
(9, 8, 1),
(22, 8, 2),
(10, 9, 1),
(11, 10, 1),
(24, 10, 2),
(12, 11, 1),
(35, 11, 4),
(13, 12, 1),
(34, 12, 4),
(14, 13, 1),
(25, 14, 1),
(27, 15, 1),
(60, 16, 2),
(61, 16, 3),
(62, 16, 4),
(63, 16, 5),
(64, 16, 6),
(65, 16, 7),
(67, 16, 8),
(38, 16, 9),
(44, 16, 10),
(46, 16, 11),
(39, 17, 9),
(42, 18, 1),
(43, 18, 9),
(45, 18, 10),
(47, 19, 1),
(48, 19, 11),
(49, 20, 1),
(51, 20, 2),
(52, 21, 1),
(53, 21, 2),
(54, 21, 3),
(55, 21, 4),
(56, 21, 5),
(57, 21, 6),
(58, 21, 7),
(59, 21, 8),
(68, 22, 1),
(69, 23, 1),
(70, 24, 1),
(71, 25, 1),
(72, 26, 1),
(73, 27, 1),
(74, 28, 1),
(79, 28, 9),
(82, 28, 10),
(75, 29, 1),
(76, 30, 1),
(77, 31, 1),
(80, 31, 9),
(78, 32, 1),
(81, 32, 9),
(83, 32, 10),
(84, 33, 1),
(86, 33, 2),
(87, 33, 3),
(89, 33, 9),
(88, 33, 10),
(85, 34, 1),
(90, 35, 1),
(91, 36, 1),
(93, 36, 2),
(95, 36, 3),
(97, 36, 6),
(99, 36, 9),
(92, 37, 1),
(94, 37, 2),
(96, 37, 3),
(98, 37, 6),
(100, 37, 9),
(101, 38, 1),
(102, 38, 2),
(104, 38, 3),
(103, 38, 6),
(105, 39, 1),
(106, 39, 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_serialsproducts`
--

CREATE TABLE `sisg_serialsproducts` (
  `id` int(11) NOT NULL,
  `serial` varchar(13) NOT NULL,
  `productId` int(11) NOT NULL,
  `distributorId` int(11) NOT NULL,
  `providerId` int(11) NOT NULL,
  `dateSale` datetime NOT NULL,
  `observations` varchar(150) DEFAULT NULL,
  `creation_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `sisg_serialsproducts`
--

INSERT INTO `sisg_serialsproducts` (`id`, `serial`, `productId`, `distributorId`, `providerId`, `dateSale`, `observations`, `creation_date`) VALUES
(1, 'Z1B8100007', 1, 7, 1, '2020-03-09 14:52:00', '1 IMP SRP-350 / CLIENTE RETIRA', '2020-03-09 23:20:33'),
(4, 'DLA7000001', 7, 2, 2, '2020-03-08 00:00:00', 'Impresora CUSTOM-KUBE', '2020-04-16 18:30:38'),
(5, 'Z1B1234567', 1, 7, 1, '2020-03-09 14:52:00', 'N.A', '2020-06-19 17:25:57'),
(6, 'Z1B4444555', 1, 7, 1, '2020-03-09 14:52:00', 'N.A', '2020-06-19 17:25:52'),
(7, 'Z1B8051654', 1, 17, 1, '2020-03-09 00:00:00', 'N.A', '2020-06-19 17:25:46'),
(20, 'Z1B8051655', 1, 18, 1, '2015-10-23 10:58:01', 'N.A', '2020-06-19 17:25:40'),
(21, 'DLA7005357', 7, 19, 2, '2017-09-29 09:25:31', 'N.A', '2020-06-19 17:25:35'),
(23, 'Z1B8532222', 1, 2, 1, '2020-03-25 17:11:19', 'N.A', '2020-06-19 17:25:28'),
(24, 'Z1B8532223', 1, 2, 1, '2020-03-25 17:21:03', 'Serial de Pruebas Internas', '2020-03-25 22:21:03'),
(25, 'Z1B8051656', 1, 18, 1, '2015-10-23 10:58:01', 'EQPS + P59285 EXPRESS 21 ', '2020-03-25 22:28:00'),
(26, 'Z1B8014815', 1, 23, 1, '2010-07-22 10:49:31', '4 imp 350', '2020-03-26 16:38:12'),
(27, 'Z1B8051657', 1, 18, 1, '2020-04-08 00:00:00', 'Enajena', '2020-04-08 23:54:56'),
(28, 'DLA7998899', 7, 25, 2, '2020-04-16 14:06:26', 'Serial de Pruebas Internas', '2020-04-16 19:06:26'),
(30, 'Z1B8887777', 1, 2, 1, '2020-04-16 14:07:37', 'Serial de Pruebas Internas', '2020-04-16 19:07:37'),
(31, 'DLA7005354', 7, 25, 2, '2020-04-29 11:44:11', 'Serial de Pruebas Internas', '2020-04-29 16:44:11'),
(32, 'ZPA0001122', 4, 2, 1, '2020-04-30 17:24:44', 'Serial de Pruebas Internas', '2020-04-30 22:24:44'),
(33, 'ZPA3333333', 4, 2, 1, '2020-05-07 15:37:35', 'Serial de Pruebas Internas', '2020-05-07 20:37:36'),
(34, 'ZPA4444444', 4, 2, 1, '2020-05-07 16:31:33', 'Serial de Pruebas Internas', '2020-05-07 21:31:33'),
(35, 'Z1B8010613', 1, 26, 1, '2009-10-26 10:17:30', '25 imp. 350', '2020-05-08 15:05:40'),
(36, 'Z1F0019999', 8, 2, 1, '2020-05-08 10:13:14', 'Serial de Pruebas Internas', '2020-05-08 15:13:14'),
(37, 'Z1F0018292', 8, 27, 1, '2020-01-20 11:54:14', '001/VAR/P-200001318/RETIRA/EV', '2020-05-08 15:18:22'),
(38, 'Z1B8014816', 1, 28, 1, '2010-07-12 10:10:48', '10 IMP. 350', '2020-05-12 19:22:22'),
(39, 'Z1B8014875', 1, 29, 1, '2010-08-26 01:39:43', '20 IMP 350', '2020-05-12 20:29:09'),
(40, 'Z1B8014817', 1, 31, 1, '2010-07-14 02:52:19', '4 IMP. 350', '2020-05-14 19:27:19'),
(41, 'Z1F6544321', 8, 25, 1, '2020-06-17 18:13:53', 'Prueba Carga a Distributor Particular', '2020-06-17 23:13:53'),
(45, 'DLA7008899', 7, 25, 2, '2020-06-17 19:15:44', 'Serial de Pruebas Internas', '2020-06-18 00:15:44'),
(53, 'Z1F4343322', 8, 2, 1, '2020-06-18 11:16:17', 'Prueba Lote', '2020-06-18 16:16:17'),
(54, 'Z1B9098765', 1, 2, 1, '2020-06-18 11:16:18', 'Prueba Lote', '2020-06-18 16:16:18'),
(55, 'Z1A3321212', 2, 2, 1, '2020-06-18 11:16:19', 'Prueba Lote', '2020-06-18 16:16:19'),
(56, 'Z1F5454545', 8, 2, 1, '2020-06-19 11:11:06', 'Serial de Pruebas Internas', '2020-06-19 16:11:07'),
(57, 'Z1F7777778', 8, 2, 1, '2020-06-19 11:14:52', 'Carga por Nota Entrega 32323', '2020-06-19 16:14:53'),
(61, 'Z1B0000000', 1, 2, 1, '2020-06-19 12:05:17', 'Serial de Pruebas Internas', '2020-06-19 17:05:18'),
(62, 'Z1F0000000', 8, 30, 1, '2020-06-19 12:06:57', 'Prueba Orden Entrega 0001', '2020-06-19 17:06:57'),
(63, 'Z1F4343320', 8, 28, 1, '2020-06-19 12:33:48', 'Loteria', '2020-06-19 17:33:48'),
(64, 'Z1B9098760', 1, 28, 1, '2020-06-19 12:33:49', 'Loteria', '2020-06-19 17:33:49'),
(65, 'Z1A3321210', 2, 28, 1, '2020-06-19 12:33:50', 'Loteria', '2020-06-19 17:33:50'),
(66, 'DLA5555555', 7, 25, 2, '2020-06-19 13:20:35', 'Serial de Pruebas Internas', '2020-06-19 18:20:35'),
(67, 'Z1F4341327', 8, 8, 1, '2020-06-22 14:18:57', 'Lote New', '2020-06-22 19:18:57'),
(68, 'Z1B9078767', 1, 8, 1, '2020-06-22 14:19:01', 'Lote New', '2020-06-22 19:19:01'),
(69, 'Z1A3321213', 2, 8, 1, '2020-06-22 14:19:02', 'Lote New', '2020-06-22 19:19:02'),
(70, 'Z1F4341328', 8, 2, 1, '2020-06-22 14:29:13', 'Lote New2', '2020-06-22 19:29:13'),
(71, 'Z1B9078769', 1, 2, 1, '2020-06-22 14:29:14', 'Lote New2', '2020-06-22 19:29:14'),
(72, 'Z1A3321214', 2, 2, 1, '2020-06-22 14:29:15', 'Lote New2', '2020-06-22 19:29:15'),
(73, 'Z1F4341329', 8, 21, 1, '2020-06-22 14:33:56', 'Lote3', '2020-06-22 19:33:56'),
(74, 'Z1B9078719', 1, 21, 1, '2020-06-22 14:33:57', 'Lote3', '2020-06-22 19:33:57'),
(75, 'Z1A3321244', 2, 21, 1, '2020-06-22 14:33:58', 'Lote3', '2020-06-22 19:33:58'),
(76, 'DLA2211222', 7, 25, 2, '2020-06-23 08:55:44', 'Serial de Pruebas Internas', '2020-06-23 13:55:44'),
(77, 'Z1F4341349', 8, 20, 1, '2020-06-23 08:56:09', 'Lote4', '2020-06-23 13:56:09'),
(78, 'Z1B9078949', 1, 20, 1, '2020-06-23 08:56:10', 'Lote4', '2020-06-23 13:56:10'),
(79, 'Z1A3321204', 2, 20, 1, '2020-06-23 08:56:11', 'Lote4', '2020-06-23 13:56:11'),
(80, 'Z1B8887766', 1, 27, 1, '2020-06-25 14:12:21', 'Lote25', '2020-06-25 19:12:21'),
(81, 'DLA1235555', 7, 27, 2, '2020-06-25 14:12:27', 'Lote25', '2020-06-25 19:12:27'),
(82, 'Z1B8887767', 1, 22, 1, '2020-06-25 14:22:20', 'Lotera', '2020-06-25 19:22:20'),
(83, 'DLA1235558', 7, 22, 2, '2020-06-25 14:22:21', 'Lotera', '2020-06-25 19:22:21'),
(84, 'Z1B8887768', 1, 2, 1, '2020-06-25 14:26:19', 'Loterina', '2020-06-25 19:26:19'),
(85, 'DLA1235559', 7, 2, 2, '2020-06-25 14:26:20', 'Loterina', '2020-06-25 19:26:20'),
(86, 'DLA5453322', 7, 2, 2, '2020-06-30 15:30:55', 'Lotona', '2020-06-30 20:30:55'),
(87, 'Z1F6564533', 8, 2, 1, '2020-06-30 15:30:59', 'Lotona', '2020-06-30 20:30:59'),
(88, 'DLA5453323', 7, 19, 2, '2020-06-30 15:47:04', 'Lota', '2020-06-30 20:47:04'),
(89, 'Z1F6564534', 8, 19, 1, '2020-06-30 15:47:05', 'Lota', '2020-06-30 20:47:05'),
(90, 'DLA5453324', 7, 20, 2, '2020-06-30 15:53:21', 'Locha', '2020-06-30 20:53:21'),
(91, 'Z1F6564535', 8, 20, 1, '2020-06-30 15:53:22', 'Locha', '2020-06-30 20:53:22'),
(92, 'DLA5453325', 7, 2, 2, '2020-06-30 16:00:26', 'Noton', '2020-06-30 21:00:27'),
(93, 'Z1F6564536', 8, 2, 1, '2020-06-30 16:00:27', 'Noton', '2020-06-30 21:00:27'),
(94, 'DLA5453327', 7, 24, 2, '2020-06-30 16:03:57', 'Nutella', '2020-06-30 21:03:57'),
(95, 'Z1F6564538', 8, 24, 1, '2020-06-30 16:03:58', 'Nutella', '2020-06-30 21:03:58'),
(96, 'DLA5453328', 7, 19, 2, '2020-06-30 16:19:52', 'Entregate', '2020-06-30 21:19:52'),
(97, 'Z1F6564539', 8, 19, 1, '2020-06-30 16:19:53', 'Entregate', '2020-06-30 21:19:53'),
(98, 'DLA5453329', 7, 22, 2, '2020-06-30 16:28:48', 'Notone', '2020-06-30 21:28:48'),
(99, 'Z1F6564540', 8, 22, 1, '2020-06-30 16:28:49', 'Notone', '2020-06-30 21:28:49'),
(100, 'DLA5453330', 7, 22, 2, '2020-06-30 16:32:51', 'Lote 2020', '2020-06-30 21:32:51'),
(101, 'Z1F6564541', 8, 22, 1, '2020-06-30 16:32:52', 'Lote 2020', '2020-06-30 21:32:52'),
(102, 'DLA5453331', 7, 19, 2, '2020-06-30 16:40:56', 'Nota 20', '2020-06-30 21:40:56'),
(103, 'Z1F6564542', 8, 19, 1, '2020-06-30 16:40:57', 'Nota 20', '2020-06-30 21:40:57'),
(104, 'DLA5453332', 7, 21, 2, '2020-06-30 16:51:01', 'Lorena', '2020-06-30 21:51:01'),
(105, 'Z1F6564543', 8, 21, 1, '2020-06-30 16:51:02', 'Lorena', '2020-06-30 21:51:02'),
(106, 'Z1B9890044', 1, 1, 1, '2020-07-01 13:56:45', 'DD', '2020-07-01 18:56:45'),
(107, 'DLA7234449', 7, 1, 2, '2020-07-01 13:57:00', 'DD', '2020-07-01 18:57:00'),
(108, 'Z1F4323233', 8, 2, 1, '2020-07-15 12:41:18', 'Serial de Pruebas Internas', '2020-07-15 17:41:18'),
(109, 'DLA7453212', 7, 25, 2, '2020-07-15 12:53:59', 'Serial de Pruebas Internas', '2020-07-15 17:53:59'),
(110, 'Z1B8025835', 1, 32, 1, '2012-10-30 03:27:01', '20 IMP 350', '2020-07-21 18:29:16'),
(111, 'Z1B8000006', 1, 33, 1, '2008-07-04 09:08:26', '10 Impresora 350', '2020-07-22 14:00:44'),
(112, 'Z1B3333333', 1, 2, 1, '2020-07-22 09:05:06', 'Serial de Pruebas Internas', '2020-07-22 14:05:06'),
(113, 'Z1B8777777', 1, 18, 1, '2020-07-22 09:06:54', 'Nota Entrega 45', '2020-07-22 14:06:54'),
(114, 'Z1B8927218', 1, 28, 1, '2020-07-22 09:09:15', 'Nota E 25', '2020-07-22 14:09:15'),
(115, 'Z1F5454376', 8, 28, 1, '2020-07-22 09:09:16', 'Nota E 25', '2020-07-22 14:09:16'),
(116, 'DLA5454312', 7, 28, 2, '2020-07-22 09:09:17', 'Nota E 25', '2020-07-22 14:09:17'),
(117, 'DLA4354545', 7, 25, 2, '2020-10-08 14:11:46', 'Serial de Pruebas Internas', '2020-10-08 19:11:46');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_serialsreplacements`
--

CREATE TABLE `sisg_serialsreplacements` (
  `id` int(11) NOT NULL,
  `serial` varchar(25) COLLATE utf8_spanish_ci NOT NULL,
  `replacementId` int(11) NOT NULL,
  `distributorId` int(11) NOT NULL,
  `providerId` int(11) NOT NULL,
  `dateSale` datetime NOT NULL,
  `observations` varchar(150) COLLATE utf8_spanish_ci DEFAULT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `sisg_serialsreplacements`
--

INSERT INTO `sisg_serialsreplacements` (`id`, `serial`, `replacementId`, `distributorId`, `providerId`, `dateSale`, `observations`, `creation_date`) VALUES
(2, 'F02A8100DC7', 9, 8, 1, '2020-03-09 14:52:00', 'RPTO/P71792/RETIRA/CF', '2020-03-09 18:20:33'),
(3, 'F05E8D00F45', 10, 1, 1, '2020-03-09 14:52:00', 'N.A', '2020-06-19 12:31:48'),
(4, 'F02A8100AC9', 9, 8, 2, '2020-03-09 14:52:00', 'RPTO/P71792/RETIRA/CF', '2020-03-12 16:36:57'),
(5, 'F0100290D95', 9, 20, 1, '2016-05-11 08:46:43', 'RPST-EQUIP-P-066537/MRW/AT', '2020-03-19 14:16:43'),
(7, 'F02FADE429C', 13, 21, 2, '2015-01-14 10:03:50', 'REPUESTOS', '2020-03-19 14:29:24'),
(8, 'F01E8D00D76', 9, 2, 1, '2020-03-25 17:25:46', 'Serial de Pruebas Internas', '2020-03-25 17:25:46'),
(9, 'F01F7FA49A7', 9, 7, 1, '2016-11-11 09:41:31', 'RPTO/P074150/RETIRA/KL', '2020-03-31 18:26:26'),
(11, 'F0112345ABD', 9, 2, 1, '2020-03-26 11:45:27', 'Serial de Pruebas Internas', '2020-03-26 11:45:27'),
(12, 'F01E8D00DCC', 9, 2, 1, '2020-04-29 11:44:33', 'Serial de Pruebas Internas', '2020-04-29 11:44:34'),
(13, 'F01B7FA49A5', 9, 2, 1, '2020-05-14 14:31:27', 'Serial de Pruebas Internas', '2020-05-14 14:31:27'),
(14, 'F01EDF43231', 9, 2, 1, '2020-06-19 12:32:34', 'Serial de Pruebas Internas', '2020-06-19 12:32:34'),
(15, 'F01B8887768', 9, 21, 1, '2020-06-25 14:28:44', 'Lotona', '2020-06-25 14:28:44'),
(16, 'F02A1235559', 13, 21, 2, '2020-06-25 14:28:44', 'Lotona', '2020-06-25 14:28:44'),
(19, 'F01DA545333', 9, 21, 1, '2020-06-30 16:56:07', 'Arepa', '2020-06-30 16:56:07'),
(20, 'F0265C4543A', 13, 21, 2, '2020-06-30 16:56:07', 'Arepa', '2020-06-30 16:56:07'),
(21, 'F019890A044', 9, 2, 1, '2020-07-01 14:56:37', 'FF', '2020-07-01 14:56:37'),
(22, 'F027234449C', 13, 2, 2, '2020-07-01 14:56:40', 'FF', '2020-07-01 14:56:40'),
(23, 'F01003D0888', 9, 34, 1, '2016-11-03 12:33:48', 'OR#15481/RETIRA/CF', '2020-07-22 09:15:34'),
(24, 'F01D567EA2C', 9, 2, 1, '2020-07-22 09:20:12', 'Lote 45', '2020-07-22 09:20:12'),
(25, 'F011237EA20', 9, 2, 1, '2020-07-22 09:20:12', 'Lote 45', '2020-07-22 09:20:12'),
(26, 'F01A567EBB0', 9, 2, 1, '2020-07-22 09:20:12', 'Lote 45', '2020-07-22 09:20:12'),
(27, 'F02D5C75A45', 13, 2, 2, '2020-07-22 09:20:13', 'Lote 45', '2020-07-22 09:20:13');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_states`
--

CREATE TABLE `sisg_states` (
  `id` int(4) NOT NULL,
  `description` varchar(40) NOT NULL,
  `countryId` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_states`
--

INSERT INTO `sisg_states` (`id`, `description`, `countryId`) VALUES
(1, 'Dtto Fed./Miranda', 232),
(2, 'Amazonas', 232),
(3, 'Anzoategui', 232),
(4, 'Apure', 232),
(5, 'Aragua', 232),
(6, 'Barinas', 232),
(7, 'Bolivar', 232),
(8, 'Carabobo', 232),
(9, 'Cojedes', 232),
(10, 'Delta Amacuro', 232),
(11, 'Falcon', 232),
(12, 'Guarico', 232),
(13, 'Lara', 232),
(14, 'Merida', 232),
(15, 'Miranda ', 232),
(16, 'Monagas', 232),
(17, 'Nueva Esparta', 232),
(18, 'Portuguesa', 232),
(19, 'Sucre', 232),
(20, 'Tachira', 232),
(21, 'Trujillo', 232),
(22, 'Yaracuy', 232),
(23, 'Zulia', 232),
(24, 'Vargas', 232);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_statesorder`
--

CREATE TABLE `sisg_statesorder` (
  `id` int(11) NOT NULL,
  `description` varchar(150) NOT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_statesorder`
--

INSERT INTO `sisg_statesorder` (`id`, `description`, `creation_date`) VALUES
(1, 'Por Recibir', '2020-08-06 10:27:39'),
(2, 'Recibido', '2020-08-06 10:27:53'),
(3, 'Asignado', '2020-08-06 10:28:02'),
(4, 'Revisión', '2020-08-06 10:28:12'),
(5, 'Pendiente Aprobación', '2020-08-06 10:28:22'),
(6, 'Presupuesto Aprobado', '2020-08-06 10:28:31'),
(7, 'Presupuesto Rechazado', '2020-08-06 10:28:41'),
(8, 'Reparando', '2020-08-06 10:28:53'),
(9, ' Facturando', '2020-08-06 10:29:04'),
(10, 'Por Entregar', '2020-08-06 10:29:15'),
(11, 'Entregado', '2020-08-06 10:29:26'),
(12, 'Anulado', '2020-08-06 10:29:41');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_technicalsoperations`
--

CREATE TABLE `sisg_technicalsoperations` (
  `id` int(11) NOT NULL,
  `providerId` int(11) NOT NULL,
  `distributorId` int(11) NOT NULL,
  `finalClientId` int(11) NOT NULL,
  `technicianId` int(11) NOT NULL,
  `typeOperationTechId` int(11) NOT NULL,
  `serial` varchar(13) COLLATE utf8_spanish_ci NOT NULL,
  `observation` varchar(100) COLLATE utf8_spanish_ci DEFAULT NULL,
  `status` varchar(50) COLLATE utf8_spanish_ci NOT NULL,
  `operation_date` datetime NOT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `sisg_technicalsoperations`
--

INSERT INTO `sisg_technicalsoperations` (`id`, `providerId`, `distributorId`, `finalClientId`, `technicianId`, `typeOperationTechId`, `serial`, `observation`, `status`, `operation_date`, `creation_date`) VALUES
(1, 1, 7, 38, 2, 3, 'Z1B8100007', '', 'DECLARADO', '2020-04-13 00:00:00', '2020-04-10 14:23:07'),
(2, 1, 7, 8, 11, 2, 'Z1B1234567', 'No presento ninguna falla.', 'PROCESADO', '2020-04-09 00:00:00', '2020-04-01 15:25:17'),
(3, 2, 19, 52, 11, 6, 'DLA7005357', 'Se hizo Ramclear.', 'PROCESADO', '2020-04-02 00:00:00', '2020-04-01 15:25:17'),
(4, 1, 7, 8, 11, 3, 'Z1B1234567', NULL, 'PROCESADO', '2020-04-22 11:22:10', '2020-04-22 11:23:50'),
(5, 1, 7, 8, 2, 4, 'Z1B1234567', NULL, 'PROCESADO', '2020-04-22 11:23:10', '0001-01-01 00:00:00'),
(6, 1, 7, 1757, 2, 3, 'Z1B1234567', 'N.A', 'PROCESADO', '2020-04-30 15:22:50', '2020-04-30 15:25:19'),
(7, 1, 2, 1, 2, 2, 'ZPA0001122', 'Limpieza', 'PROCESADO', '2020-04-30 17:27:10', '2020-04-30 17:27:34'),
(8, 1, 7, 1, 2, 4, 'Z1B1234567', 'N.A', 'PROCESADO', '2020-05-05 12:16:06', '2020-05-05 12:16:38'),
(9, 2, 2, 1757, 2, 3, 'DLA7000001', 'N.A', 'PROCESADO', '2020-05-05 14:23:18', '2020-05-05 14:23:54'),
(12, 2, 25, 1757, 2, 2, 'DLA7998899', 'N.A', 'PROCESADO', '2020-05-05 16:46:26', '2020-05-05 16:47:46'),
(13, 2, 25, 1757, 2, 6, 'DLA7998899', 'N.A', 'PROCESADO', '2020-05-05 17:42:40', '2020-05-05 17:42:54'),
(14, 1, 27, 1, 2, 4, 'Z1F0018292', 'Instalacion', 'PROCESADO', '2020-05-08 10:31:45', '2020-05-08 10:32:10'),
(15, 1, 7, 1757, 2, 2, 'Z1B1234567', 'Mantto', 'PROCESADO', '2020-06-17 16:52:15', '2020-06-17 16:54:00'),
(16, 1, 7, 1757, 2, 3, 'Z1B1234567', 'Cambio de MEMO', 'PROCESADO', '2020-06-17 17:40:58', '2020-06-17 17:41:53'),
(17, 1, 7, 1757, 2, 3, 'Z1B1234567', 'Cambio de MEMO', 'PROCESADO', '2020-06-17 18:06:41', '2020-06-17 18:07:22'),
(18, 1, 7, 44, 2, 3, 'Z1B1234567', 'Limpieza de cabezales', 'PROCESADO', '2020-07-16 10:00:18', '2020-07-16 10:00:59'),
(19, 2, 2, 44, 11, 2, 'DLA7234449', 'Limpieza', 'PROCESADO', '2020-07-16 19:06:48', '2020-07-16 19:07:14');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_technicians`
--

CREATE TABLE `sisg_technicians` (
  `id` int(11) NOT NULL,
  `rif` varchar(12) NOT NULL,
  `description` varchar(150) NOT NULL,
  `address` varchar(150) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `enable` tinyint(1) NOT NULL,
  `creation_date` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_technicians`
--

INSERT INTO `sisg_technicians` (`id`, `rif`, `description`, `address`, `phone`, `email`, `enable`, `creation_date`) VALUES
(1, 'V123456789', 'Duglas Méndez', 'Av. México', '582123541160', 'dmendez@gmail.com', 1, '2019-06-26 11:02:47'),
(2, 'V145264614', 'Pablo Moya', 'Av.Cl 80 con # 120, Milinos de Vientos, Bogota D.C.', '(+57) 322 8491444', 'tecnicopm@tfhka.com', 1, '2019-06-26 15:13:50'),
(3, 'V888385359', 'Veronica Gomez', 'Av. Libertador, Edf. Riva, Local 3-1. Planta Baja. Los Cortijos. Caracas ? Venezuela', '+58 212 3541161', 'vgomez@tfhka.com', 1, '2019-06-26 13:42:27'),
(7, 'V205405662', 'Gloria Noguera', 'Av. Boulevard del Cafetal CC Plaza Las Americas Nivel Mirador Loc. V-56 Urb. El Cafetal Caracas', '2129860201', 'gnoguera@bitsamericas.com', 1, '2019-06-26 11:27:37'),
(8, 'V186035484', 'Erika Dominguez', 'Av. Boulevard del Cafetal CC Plaza Las Americas Nivel Mirador Loc. V-56 Urb. El Cafetal Caracas', '2129860201', 'edominguez@bitsamericas.com', 1, '2019-06-26 13:30:21'),
(9, 'V999888777', 'Maria Baez', 'Av. Boulevard del Cafetal CC Plaza Las Americas Nivel Mirador Loc. V-56 Urb. El Cafetal Caracas', '2129860201', 'maria78bz@tfhka.com', 1, '2019-06-26 15:31:22'),
(10, 'E012345678', 'Pepeto Bolsa', 'La California Norte', '4265329339', 'pepito56@tfhka.com', 1, '2019-06-26 17:48:19'),
(11, 'V000000000', 'Técnico Virtual TFHKA', 'Callejon Gutierrez', '02122428877', 'tecnico@bitsamericas.com', 1, '2020-04-13 23:27:30');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_techniciansdistributors`
--

CREATE TABLE `sisg_techniciansdistributors` (
  `id` int(11) NOT NULL,
  `techniciansId` int(11) NOT NULL,
  `distributorsId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_techniciansdistributors`
--

INSERT INTO `sisg_techniciansdistributors` (`id`, `techniciansId`, `distributorsId`) VALUES
(1, 1, 1),
(6, 1, 7),
(15, 2, 2),
(2, 2, 7),
(12, 2, 8),
(16, 2, 25),
(17, 2, 27),
(3, 3, 1),
(8, 7, 7),
(13, 7, 8),
(9, 8, 1),
(10, 8, 7),
(11, 9, 2),
(14, 11, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_techniciansusers`
--

CREATE TABLE `sisg_techniciansusers` (
  `id` int(11) NOT NULL,
  `techniciansId` int(11) NOT NULL,
  `userId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_techniciansusers`
--

INSERT INTO `sisg_techniciansusers` (`id`, `techniciansId`, `userId`) VALUES
(1, 1, 2),
(2, 2, 7),
(3, 3, 29),
(6, 7, 32),
(7, 8, 33),
(8, 9, 34),
(9, 10, 35),
(10, 11, 69);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_typeoperationstechs`
--

CREATE TABLE `sisg_typeoperationstechs` (
  `id` int(11) NOT NULL,
  `description` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `sisg_typeoperationstechs`
--

INSERT INTO `sisg_typeoperationstechs` (`id`, `description`, `creation_date`) VALUES
(1, 'ENAJENACION TECNICA', '2020-04-15 19:09:09'),
(2, 'INSPECCIÓN ANUAL', '2020-04-15 19:09:09'),
(3, 'REPARACIÓN', '2020-04-15 19:09:09'),
(4, 'ADAPTACIÓN', '2020-04-15 19:09:09'),
(5, 'SUSTITUCIÓN DE MEMORIA FISCAL', '2020-04-15 19:09:09'),
(6, 'SUSTITUCIÓN DE MEMORIA DE AUDITORÍA', '2020-04-15 19:09:09'),
(7, 'ALTERACIÓN Ó REMOCIÓN DE DISPOSITIVOS DE SEGURIDAD', '2020-04-15 19:09:09'),
(8, 'REPORTE DE PÉRDIDA Ó ROBO POR PARTE DEL DISTRIBUIDOR', '2020-04-15 19:09:09'),
(9, 'REPORTE PÉDIDA Ó ROBO POR PARTE DEL USUARIO', '2020-04-15 19:09:09'),
(10, 'DESINCORPORACIÓN', '2020-04-15 19:09:09');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_typesfailures`
--

CREATE TABLE `sisg_typesfailures` (
  `id` int(11) NOT NULL,
  `description` varchar(150) NOT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_typesfailures`
--

INSERT INTO `sisg_typesfailures` (`id`, `description`, `creation_date`) VALUES
(0, 'POR DETERMINAR', '2020-08-11 09:04:17'),
(1, 'ERROR EN MEMORIA FISCAL', '2020-08-11 08:45:14'),
(2, 'ERROR DE MEMORIA DE AUDITORIA', '2020-08-11 08:45:20'),
(3, 'ERROR RAM CLEAR', '2020-08-11 08:38:32'),
(4, 'EQUIPO NO PRENDE', '2020-08-11 08:38:45'),
(5, 'FALLA DE COMUNICACIÓN', '2020-08-11 08:38:55'),
(6, 'ERROR  DE KIT FISCAL', '2020-08-11 08:39:05'),
(7, 'NO IMPRIME', '2020-08-11 08:39:18'),
(8, 'ERROR 114', '2020-08-11 08:39:31'),
(9, 'ERROR 140', '2020-08-11 08:39:42'),
(10, 'FALLA  EN MÓDULO FISCAL', '2020-08-11 08:39:55'),
(11, 'FALLA EN EL MECANISMO DE IMPRESIÓN', '2020-08-11 08:40:05'),
(12, 'FALLA DE SENSORES', '2020-08-11 08:40:20'),
(13, 'ERROR TAMPER', '2020-08-11 08:40:29'),
(14, 'VISOL CLIENTE NO FUNCIONA', '2020-08-11 08:40:39'),
(15, 'VISOR OPERADOR NO FUNCIONA', '2020-08-11 08:40:49'),
(16, 'FALLA DE TECLADOS', '2020-08-11 08:40:58'),
(17, 'ERROR BUS DE DATA EN CORTO', '2020-08-11 08:41:09'),
(18, 'CORTODOR AUTOMATICO NO FUNCIONA', '2020-08-11 08:41:20'),
(19, 'ERROR 78', '2020-08-11 08:41:34'),
(20, 'BALANZA NO PERMITE CALIBRAR', '2020-08-11 08:41:43'),
(21, 'BALANZA NO COMUNICA', '2020-08-11 08:41:53'),
(22, 'FALLA DE PANEL DE CONTROL', '2020-08-11 08:42:04'),
(23, 'EQUIPO BLOQUEADO', '2020-08-11 08:42:16'),
(24, 'ERROR MEMORIA DE TRABAJO', '2020-08-11 08:42:25'),
(25, 'ERROR BACKUP', '2020-08-11 08:42:33'),
(26, 'ERROR DE FECHA', '2020-08-11 08:42:44'),
(27, 'ERROR EN ACTUALIZACIÓN DE FIRMWARE', '2020-08-11 08:43:00'),
(28, 'RE-ENAJENACION', '2020-08-11 08:43:09'),
(29, 'ERROR EN HORA', '2020-08-11 08:43:18'),
(30, 'ERROR 01 FE', '2020-08-11 08:43:27'),
(31, 'ERROR 03 FE', '2020-08-11 08:43:35'),
(32, 'ERROR 76', '2020-08-11 08:43:45'),
(33, 'DETERIORO DE ETIQUETA FISCAL', '2020-08-11 08:43:55'),
(34, 'FISCALIZACIÓN', '2020-08-11 08:44:05'),
(35, 'CONFIGURACIÓN DE PARÁMETROS', '2020-08-11 08:44:16'),
(36, 'ERROR DE TRANSMISIÓN', '2020-08-11 08:44:25'),
(37, 'ERROR DE CONFIGURACIÓN DEL DISPOSITIVO', '2020-08-11 08:44:35'),
(38, 'FALLA DE SOLENOIDE', '2020-08-11 08:47:07'),
(39, 'GOLPEADA', '2020-08-11 08:47:19'),
(40, 'OTRA', '2020-08-11 08:47:19');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_users`
--

CREATE TABLE `sisg_users` (
  `id` int(11) NOT NULL,
  `rolId` int(20) NOT NULL,
  `username` varchar(150) NOT NULL,
  `password` varchar(150) NOT NULL,
  `enable` tinyint(1) NOT NULL,
  `creation_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_users`
--

INSERT INTO `sisg_users` (`id`, `rolId`, `username`, `password`, `enable`, `creation_date`) VALUES
(1, 1, 'pmoya@bitsamericas.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-06-14 14:16:52'),
(2, 10, 'dmendez@gmail.com', 'OxoVf52O+XgkSMRSxV92yPFhmUM=', 1, '2019-06-19 17:52:21'),
(7, 10, 'tecnicopm@tfhka.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-06-26 15:14:26'),
(8, 1, 'admin@bitsamericas.com', 'btWDPPNShuv4Zit7WUnw10K77D8=', 1, '2019-04-25 16:55:53'),
(19, 9, 'japonte@bitsamericas.com', 'vVmDqPro9Bh5WKqvCyfbOelcZA0=', 1, '2019-06-18 13:36:08'),
(27, 9, 'pmmoyapablo@gmail.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-06-19 12:57:50'),
(28, 9, 'pmmoyapablo587@hotmail.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-12-11 16:27:10'),
(29, 10, 'vgomez@tfhka.com', 'sPzo1Fbk7D5nKthgkRNEqjIqEJk=', 1, '2019-06-20 14:22:49'),
(32, 10, 'gnoguera@bitsamericas.com', 'g+lHc0baBoTmqBZrq9Ka+s3Sgq4=', 1, '2019-06-26 11:29:34'),
(33, 10, 'edominguez@bitsamericas.com', 'hgrHyMUi5sibIC77Ms+3M7HAbNg=', 1, '2019-06-26 13:30:29'),
(34, 10, 'maria78bz@tfhka.com', 'wSM+iS3RUkhqkzBJfrxKyNM+C9A=', 1, '2019-06-26 15:31:25'),
(35, 10, 'pepito56@tfhka.com', 'KUWr0LClUHcVXBirJcXxOkd7NsM=', 1, '2019-06-26 17:48:20'),
(36, 11, 'dev@bitsamericas.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-07-30 10:38:32'),
(37, 11, 'detripos@hotmail.com', 'ZMOPShSw1c0LjLrvOFVOfZoOJEI=', 1, '2019-07-30 16:49:55'),
(38, 11, 'sismex@gmail.com', '/zzIAxwqeM16V4xpDRZTxkv3KDA=', 1, '2019-07-30 16:50:47'),
(39, 11, 'seinca.opera.arodriguez@hotmail.com', 'ToDVheGrcAU9McxLViuy6SMzy1k=', 0, '2019-07-30 16:51:36'),
(40, 11, 'dev2@bitsamericas.com', 'QWGDtYxa+1pbf6PUXFn7bgR3XbU=', 1, '2019-08-09 10:11:54'),
(41, 5, 'mramirez@bitsamericas.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-08-14 17:37:45'),
(42, 5, 'paguirre@bitsamericas.com', 'N33jVcFy8jS7QTim5jt5TxURLDk=', 1, '2019-08-14 17:31:10'),
(43, 3, 'jserrano@bitsamericas.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-08-14 17:37:57'),
(44, 4, 'rmoreno@bitsamericas.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-08-14 17:38:09'),
(45, 5, 'lmarchan@bitsamericas.com', 'wFTD2493jPkbdahV5GGeEJYJmf0=', 1, '2019-08-14 17:35:46'),
(46, 3, 'nsalazar@bitsamericas.com', 'qxoeaypPXjNaBDaNRPE2zeQBRGA=', 1, '2019-08-15 09:21:43'),
(47, 5, 'zbolivar@bitsamericas.com', 'KM9dwyj686+BSk6O21hK2lbSWzw=', 1, '2019-08-15 09:26:20'),
(48, 2, 'rvalderrama@bitsamericas.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2020-04-14 19:18:06'),
(49, 3, 'ycmartinez@bitsamericas.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-08-23 15:29:51'),
(50, 8, 'jlealz@bitsamericas.com', 'Y9A2WCl3/AtVG/nCCEzxOVKOPJ8=', 1, '2019-08-15 09:34:57'),
(51, 1, 'dmontilla@bitsamericas.com', 'oFTXIzTsSx0NcFOZEqJ7BwMQHEc=', 1, '2019-08-15 09:39:43'),
(52, 6, 'esantana@bitsamericas.com', 'sYNREKFt+iSCWW8kqb+F5amJN1I=', 1, '2019-08-15 09:41:06'),
(53, 6, 'ygil@bitsamericas.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2020-09-08 12:53:13'),
(54, 7, 'jcenteno@bitsamericas.com', '6MygC/h9dmhL2Kk9CP5OUnfeRgk=', 1, '2019-08-15 09:50:06'),
(55, 6, 'pfanay@bitsamericas.com', 'SXwXhJTS9nylPKrid128UPjwgig=', 1, '2019-08-15 09:55:41'),
(56, 8, 'pmendez@tfhka.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2019-08-23 11:03:24'),
(58, 9, 'pmmoyapablo@hotmail.com', '5aqu1n6X1xxsqxUX25j1KN537sk=', 1, '2019-12-11 16:29:00'),
(59, 12, 'sgove@tfhka.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2020-03-19 12:03:46'),
(60, 9, 'client16048@tfhka.com', 'fZ9hFlfcsTd3aaLtvu2F0k90mUU=', 1, '2020-03-19 12:35:06'),
(61, 9, 'client114084@tfhka.com', 'ODAdvdGsNom6eRYah/TdNunfmdo=', 1, '2020-03-19 13:41:09'),
(62, 9, 'client295597754@tfhka.com', 'qivSprru4oDU6G0S+1/fN7xr+ho=', 1, '2020-03-19 14:11:33'),
(63, 9, 'client110055@tfhka.com', 'CS6me+hq5M5uvonoTr5sHh2kJkM=', 1, '2020-03-19 14:16:39'),
(64, 9, 'client150570@tfhka.com', 'vaw9ceapDkn6ysecSkag66u4/cs=', 1, '2020-03-19 14:23:33'),
(65, 9, 'client110009@tfhka.com', 'ScZotNrRsl1WdUnvduDKnWMyQEQ=', 1, '2020-03-26 11:36:41'),
(66, 9, 'client110364@tfhka.com', 'lD0p/IIjIQc9qHhNOth7upIvQwU=', 1, '2020-03-26 11:38:09'),
(67, 9, 'client110103@tfhka.com', 'P0ZG9Y56zY7cpAMNPmG4VGpSVE8=', 1, '2020-03-26 11:40:00'),
(68, 9, 'client110162@tfhka.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2020-04-17 12:54:00'),
(69, 10, 'tecnico@bitsamericas.com', 'k/ajhLDG9UQ9z9XTY5ugWp8sbAI=', 1, '2020-04-13 23:27:30'),
(70, 9, 'client110392@tfhka.com', '8u6ap8wFVW4+NB8ZCHDj2a0zrGI=', 1, '2020-05-08 10:05:34'),
(71, 9, 'client412313789@tfhka.com', 'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, '2020-05-08 10:20:49'),
(72, 9, 'client110263@tfhka.com', 'QCWMeJ1WtAN1aXF9CQd4KTJXLqE=', 1, '2020-05-12 14:22:05'),
(73, 9, 'client110436@tfhka.com', 'm++9H69bOudYHqA0FHIgmPH/Siw=', 1, '2020-05-12 15:29:05'),
(74, 9, 'client110033@tfhka.com', 'FTpPSSaRi1VkKHcjySWKghdztVg=', 1, '2020-05-12 15:30:39'),
(75, 9, 'client110245@tfhka.com', 'DZHQO2joefxVvMLlUdumjViBiSc=', 1, '2020-05-14 14:27:14'),
(76, 9, 'client110225@tfhka.com', 'KvQIEoV2Pdd36ieFG7UD9vse8xM=', 1, '2020-07-21 13:29:10'),
(77, 9, 'client110042@tfhka.com', '0t1dP1DNHbkOel3NnGDQLVaTdx0=', 1, '2020-07-22 09:00:37'),
(78, 9, 'client110595@tfhka.com', '9Q9LlIVw3OKNAz0BocyM8CMkTzw=', 1, '2020-07-22 09:15:28');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_workshopbinnacles`
--

CREATE TABLE `sisg_workshopbinnacles` (
  `id` int(11) NOT NULL,
  `orderId` int(11) NOT NULL,
  `statusId` int(11) NOT NULL,
  `userId` int(11) NOT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `observation` varchar(500) COLLATE utf8_spanish2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `sisg_workshopbinnacles`
--

INSERT INTO `sisg_workshopbinnacles` (`id`, `orderId`, `statusId`, `userId`, `creation_date`, `observation`) VALUES
(1, 1, 1, 14, '2020-09-01 14:15:05', 'Reistrada por el Distribuidor'),
(2, 1, 2, 14, '2020-09-24 13:17:45', 'No trajo libro de control'),
(3, 1, 3, 11, '2020-09-24 13:44:25', NULL),
(4, 3, 2, 11, '2020-09-25 13:44:23', NULL),
(5, 3, 12, 10, '2020-09-25 13:44:47', 'Falta de presupuesto'),
(6, 21, 1, 1, '2020-09-25 19:28:31', 'Chicha'),
(7, 22, 1, 1, '2020-09-25 20:12:37', 'Nanana'),
(8, 23, 1, 1, '2020-09-25 20:15:44', 'dsfsdfsd'),
(9, 24, 2, 1, '2020-10-08 14:16:59', ''),
(10, 25, 2, 1, '2020-10-09 09:37:59', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sisg_workshoporders`
--

CREATE TABLE `sisg_workshoporders` (
  `id` int(11) NOT NULL,
  `numerOrder` varchar(30) NOT NULL,
  `kindEquipment` int(1) NOT NULL,
  `equipment` varchar(100) NOT NULL,
  `serial` varchar(13) NOT NULL,
  `warranty` int(2) DEFAULT NULL,
  `distributorId` int(11) NOT NULL,
  `typeFailurId` int(11) NOT NULL,
  `stateOrderId` int(11) NOT NULL,
  `deliveryOrderId` int(11) DEFAULT NULL,
  `employeeId` int(11) NOT NULL,
  `firmwareVersion` varchar(45) DEFAULT NULL,
  `deliverDate` datetime DEFAULT NULL,
  `receptionDate` datetime DEFAULT NULL,
  `alienationDate` datetime DEFAULT NULL,
  `expirationDate` datetime DEFAULT NULL,
  `address` varchar(150) NOT NULL,
  `contact` varchar(150) NOT NULL,
  `phone` varchar(50) DEFAULT NULL,
  `insertionOrigin` tinyint(1) NOT NULL,
  `workDone` varchar(150) DEFAULT NULL,
  `customerReview` varchar(150) NOT NULL,
  `observationTechnical` varchar(150) DEFAULT NULL,
  `extraObservation` varchar(150) DEFAULT NULL,
  `creation_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sisg_workshoporders`
--

INSERT INTO `sisg_workshoporders` (`id`, `numerOrder`, `kindEquipment`, `equipment`, `serial`, `warranty`, `distributorId`, `typeFailurId`, `stateOrderId`, `deliveryOrderId`, `employeeId`, `firmwareVersion`, `deliverDate`, `receptionDate`, `alienationDate`, `expirationDate`, `address`, `contact`, `phone`, `insertionOrigin`, `workDone`, `customerReview`, `observationTechnical`, `extraObservation`, `creation_date`) VALUES
(1, '00001', 1, '1', 'Z1B8100007', 0, 8, 6, 1, 1, 17, NULL, '2020-08-30 02:01:00', '2020-08-21 00:00:00', '0001-01-01 00:00:00', '2020-08-31 00:00:00', 'Av. Lecuna esquina el conde', 'Mauren Garcia', '322 8491444', 1, NULL, 'Solamente se envio la impresora', NULL, NULL, '2020-10-09 15:06:18'),
(2, '00002', 1, '1', 'DLA1235555', 0, 27, 6, 2, 1, 17, NULL, '2020-08-30 00:00:00', '2020-08-21 00:00:00', '0001-01-01 00:00:00', '2020-08-31 00:00:00', 'Av. Lecuna esquina el conde', 'Mauren Garcia', NULL, 1, NULL, 'Solamente se envio la impresora', NULL, NULL, '2020-10-09 15:06:11'),
(3, '00003', 1, '8', 'Z1F7777778', 0, 2, 4, 1, 1, 17, NULL, '2020-08-30 02:01:00', '2020-08-21 00:00:00', '0001-01-01 00:00:00', '2020-08-31 00:00:00', 'Av. Lecuna esquina el conde', 'Mauren Garcia', '322 8491444', 1, NULL, 'Solamente se envio la impresora', NULL, NULL, '2020-10-09 15:05:17'),
(4, '00004', 1, '0', 'Z1B1234567', 0, 7, 6, 12, 1, 17, NULL, '2020-08-28 15:25:12', '2020-08-20 15:25:12', '0001-01-01 00:00:00', '2020-08-30 15:25:12', 'Av. Lecuna esquina el conde', 'Mauren Garcia', '322898922', 1, NULL, 'Solamente se envio la impresora', 'No prende', 'Ninguna todo ok', '2020-10-09 15:06:25'),
(5, '00005', 1, '5', 'Z1B1234567', NULL, 34, 0, 1, 2, 10, NULL, '2020-09-16 16:18:57', '2020-09-01 16:18:57', '2001-01-18 00:00:00', '2020-09-16 16:18:57', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'Na', 'No prende', NULL, '2020-09-21 13:48:10'),
(6, '00006', 2, '8', 'F01E8D00D76', NULL, 2, 0, 1, 8, 10, NULL, '2020-09-16 17:39:48', '2020-09-01 17:39:48', '0001-01-01 00:00:00', '2020-09-16 17:39:49', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'Limpieza', 'No fifa', NULL, '2020-09-21 12:09:37'),
(7, '00007', 1, '79', 'Z1A3321204', NULL, 14, 0, 1, 10, 10, NULL, '2020-09-23 17:07:05', '2020-09-08 17:07:05', '0001-01-01 00:00:00', '2020-09-23 17:07:05', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'NA', 'No prende ni apaaga', NULL, '2020-09-21 12:09:33'),
(8, '00008', 1, '75', 'Z1A3321244', NULL, 21, 0, 1, 11, 10, NULL, '2020-09-30 13:32:22', '2020-09-15 13:32:22', '0001-01-01 00:00:00', '2020-09-30 13:32:22', 'Callejon Gutierrez', 'Maria Morena', '04148491448', 0, NULL, 'Reset();', 'No prende', 'NA', '2020-09-21 12:08:48'),
(9, '00009', 2, '0', 'BC6553', NULL, 2, 0, 1, 12, 10, NULL, '2020-09-30 13:38:15', '2020-09-15 13:38:15', '0001-01-01 00:00:00', '2020-09-30 13:38:15', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'NA', 'Blblabla', 'N.A', '2020-09-21 12:08:44'),
(10, '00010', 1, '110', 'Z1B8025835', NULL, 21, 0, 1, 13, 10, NULL, '2020-10-06 11:33:46', '2020-09-21 11:33:46', '0001-01-01 00:00:00', '2020-10-06 11:33:46', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'RAm Clear', 'No prende', 'NA', '2020-09-21 12:08:40'),
(14, '00014', 3, '3', '2340098', NULL, 21, 0, 1, 17, 10, NULL, '2020-10-06 14:02:34', '2020-09-21 14:02:34', '0001-01-01 00:00:00', '2020-10-06 14:02:34', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'NA', 'No prende', NULL, '2020-09-21 14:02:34'),
(15, '00015', 3, '0', '0000000000', NULL, 2, 0, 1, 18, 10, NULL, '2020-10-06 14:05:30', '2020-09-21 14:05:30', '0001-01-01 00:00:00', '2020-10-06 14:05:30', 'Callejon Gutierrez', 'Maria Morena', '04148491448', 0, NULL, 'Ram C', 'NNNN', NULL, '2020-09-21 14:05:30'),
(16, '00016', 2, '15', 'F01B8887768', NULL, 21, 0, 1, 19, 10, NULL, '2020-10-06 14:12:26', '2020-09-21 14:12:26', '0001-01-01 00:00:00', '2020-10-06 14:12:26', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'TT', 'Nada', 'NA', '2020-09-21 14:12:26'),
(18, '00018', 1, '55', 'Z1A3321212', NULL, 2, 0, 1, 21, 10, NULL, '2020-10-07 10:25:04', '2020-09-22 10:25:04', '0001-01-01 00:00:00', '2020-10-07 10:25:04', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'NA', 'No fount', NULL, '2020-09-22 10:25:04'),
(19, '00019', 1, '32', 'ZPA0001122', NULL, 2, 0, 1, 22, 10, NULL, '2020-10-07 11:15:06', '2020-09-22 11:15:06', '2020-05-11 12:17:33', '2020-10-07 11:15:06', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'Limpieza', 'Nojoda', NULL, '2020-09-22 11:15:06'),
(20, '00020', 1, '107', 'DLA7234449', NULL, 2, 0, 1, 23, 10, NULL, '2020-10-08 12:08:47', '2020-09-23 12:08:47', '2020-07-16 19:06:29', '2020-10-08 12:08:47', 'Calle luna calle sol', 'Victor Luna', '04148491477', 0, NULL, 'Reset', 'Nojoda', 'No trajo caja', '2020-09-23 12:08:47'),
(21, '00021', 2, '0', 'TY0000023', NULL, 2, 0, 1, 24, 10, NULL, '2020-10-10 19:27:25', '2020-09-25 19:27:25', '0001-01-01 00:00:00', '2020-10-10 19:27:25', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'RCAL', 'Nanananana', 'Chicha', '2020-09-25 19:50:01'),
(22, '00022', 2, '13', 'T804343432', NULL, 25, 0, 1, 26, 10, NULL, '2020-10-10 20:12:35', '2020-09-25 20:12:35', '0001-01-01 00:00:00', '2020-10-10 20:12:35', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'Limpieza', 'SFSFsfsfsf', 'Nanana', '2020-09-25 20:13:08'),
(23, '00023', 1, '25', 'Z1B8051656', NULL, 18, 0, 2, 27, 10, '', '2020-10-10 23:41:00', '2020-09-25 23:41:00', '0001-01-01 00:00:00', '2020-10-10 23:41:00', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'adadad', 'Nanannaa', 'Hola', '2020-09-25 23:41:00'),
(24, '00024', 1, '7', 'DLA4354545', NULL, 2, 0, 2, 28, 10, NULL, '2020-10-23 14:16:58', '2020-10-08 14:16:58', '0001-01-01 00:00:00', '2020-10-23 14:16:58', 'Callejon Gutierrez', 'Maria Morena', '04148491448', 0, NULL, 'NA', 'No Arranca', NULL, '2020-10-08 14:16:58'),
(25, '00025', 2, '4', '0000000000', NULL, 2, 0, 2, 29, 10, NULL, '2020-10-24 09:37:55', '2020-10-09 09:37:55', '1753-01-01 00:00:00', '2020-10-24 09:37:55', 'Callejon Gutierrez', 'Pedro Perez', '04148491448', 0, NULL, 'Limpieza', 'No Arranca', NULL, '2020-10-09 09:37:55');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `sisg_accessories`
--
ALTER TABLE `sisg_accessories`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_accessoriesorders`
--
ALTER TABLE `sisg_accessoriesorders`
  ADD PRIMARY KEY (`id`),
  ADD KEY `orderId` (`orderId`),
  ADD KEY `accesoryId` (`accesoryId`);

--
-- Indices de la tabla `sisg_accessroles`
--
ALTER TABLE `sisg_accessroles`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_activities`
--
ALTER TABLE `sisg_activities`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sisg_activities_ibfk_1` (`employeeId`);

--
-- Indices de la tabla `sisg_alienations`
--
ALTER TABLE `sisg_alienations`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `serial` (`serial`),
  ADD KEY `sisg_alienations_ibfk_1` (`providerId`),
  ADD KEY `sisg_alienations_ibfk_2` (`distributorId`),
  ADD KEY `sisg_alienations_ibfk_3` (`finalclientId`);

--
-- Indices de la tabla `sisg_categories`
--
ALTER TABLE `sisg_categories`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_chargues`
--
ALTER TABLE `sisg_chargues`
  ADD PRIMARY KEY (`id`),
  ADD KEY `rolId` (`rolId`);

--
-- Indices de la tabla `sisg_countries`
--
ALTER TABLE `sisg_countries`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_deliveryorder`
--
ALTER TABLE `sisg_deliveryorder`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_departaments`
--
ALTER TABLE `sisg_departaments`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_developersclients`
--
ALTER TABLE `sisg_developersclients`
  ADD PRIMARY KEY (`id`),
  ADD KEY `document` (`document`);

--
-- Indices de la tabla `sisg_developersclientsusers`
--
ALTER TABLE `sisg_developersclientsusers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `developersclientsId` (`developersclientsId`),
  ADD KEY `userId` (`userId`);

--
-- Indices de la tabla `sisg_distributors`
--
ALTER TABLE `sisg_distributors`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `rif` (`rif`);

--
-- Indices de la tabla `sisg_distributorsproviders`
--
ALTER TABLE `sisg_distributorsproviders`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `distributorsId_2` (`distributorsId`,`providerId`),
  ADD KEY `distributorsId` (`distributorsId`),
  ADD KEY `providerId` (`providerId`);

--
-- Indices de la tabla `sisg_distributorsusers`
--
ALTER TABLE `sisg_distributorsusers`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `distributorsId_2` (`distributorsId`,`userId`),
  ADD KEY `distributorsId` (`distributorsId`),
  ADD KEY `userId` (`userId`);

--
-- Indices de la tabla `sisg_employees`
--
ALTER TABLE `sisg_employees`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `rif` (`rif`),
  ADD UNIQUE KEY `email` (`email`),
  ADD KEY `departamentId` (`departamentId`),
  ADD KEY `chargueId` (`chargueId`);

--
-- Indices de la tabla `sisg_employeesusers`
--
ALTER TABLE `sisg_employeesusers`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `employeeId_2` (`employeeId`),
  ADD UNIQUE KEY `userId_2` (`userId`),
  ADD KEY `employeeId` (`employeeId`),
  ADD KEY `userId` (`userId`);

--
-- Indices de la tabla `sisg_finalsclients`
--
ALTER TABLE `sisg_finalsclients`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `rif` (`rif`);

--
-- Indices de la tabla `sisg_finalsclientsusers`
--
ALTER TABLE `sisg_finalsclientsusers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `finalsclientsId` (`finalsclientsId`,`userId`);

--
-- Indices de la tabla `sisg_fiscalsoperations`
--
ALTER TABLE `sisg_fiscalsoperations`
  ADD PRIMARY KEY (`id`),
  ADD KEY `distributorsId` (`providerId`,`distributorId`,`technicianId`,`finalClientId`,`serial`),
  ADD KEY `sisg_fiscalsoperations_ibfk_1` (`technicianId`),
  ADD KEY `sisg_fiscalsoperations_ibfk_2` (`distributorId`),
  ADD KEY `sisg_fiscalsoperations_ibfk_3` (`finalClientId`);

--
-- Indices de la tabla `sisg_marks`
--
ALTER TABLE `sisg_marks`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_menus`
--
ALTER TABLE `sisg_menus`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_models`
--
ALTER TABLE `sisg_models`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`),
  ADD KEY `markId` (`markId`);

--
-- Indices de la tabla `sisg_photographsorder`
--
ALTER TABLE `sisg_photographsorder`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_prefixes`
--
ALTER TABLE `sisg_prefixes`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `initCorrelative` (`initCorrelative`),
  ADD UNIQUE KEY `initAlphaNum` (`initAlphaNum`);

--
-- Indices de la tabla `sisg_products`
--
ALTER TABLE `sisg_products`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `modelId_2` (`modelId`),
  ADD UNIQUE KEY `code` (`code`),
  ADD KEY `categoryId` (`categoryId`),
  ADD KEY `modelId` (`modelId`);

--
-- Indices de la tabla `sisg_productsaccessories`
--
ALTER TABLE `sisg_productsaccessories`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `paresId` (`productId`,`accessoryId`),
  ADD KEY `productId` (`productId`),
  ADD KEY `accessoryId` (`accessoryId`);

--
-- Indices de la tabla `sisg_productsreplacements`
--
ALTER TABLE `sisg_productsreplacements`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `paresId` (`productId`,`replacementId`),
  ADD KEY `productId` (`productId`),
  ADD KEY `replacementId` (`replacementId`);

--
-- Indices de la tabla `sisg_profiles`
--
ALTER TABLE `sisg_profiles`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_providers`
--
ALTER TABLE `sisg_providers`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_replacements`
--
ALTER TABLE `sisg_replacements`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `code` (`code`),
  ADD KEY `modelId` (`modelId`);

--
-- Indices de la tabla `sisg_replacementsopetechs`
--
ALTER TABLE `sisg_replacementsopetechs`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `serial` (`serial`),
  ADD KEY `sisg_replacementsopetechs_ibfk_1` (`operationTechId`),
  ADD KEY `sisg_replacementsopetechs_ibfk_2` (`replacementId`);

--
-- Indices de la tabla `sisg_replacementsorders`
--
ALTER TABLE `sisg_replacementsorders`
  ADD PRIMARY KEY (`id`),
  ADD KEY `orderId` (`orderId`),
  ADD KEY `replacementId` (`replacementId`);

--
-- Indices de la tabla `sisg_roles`
--
ALTER TABLE `sisg_roles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `accessId` (`accessId`),
  ADD KEY `ProfileId` (`profileId`);

--
-- Indices de la tabla `sisg_rolesmenus`
--
ALTER TABLE `sisg_rolesmenus`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `MenuId` (`MenuId`,`RolId`),
  ADD KEY `sisg_rolesmenus_ibfk_2` (`RolId`);

--
-- Indices de la tabla `sisg_serialsproducts`
--
ALTER TABLE `sisg_serialsproducts`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `serial` (`serial`),
  ADD KEY `productId` (`productId`),
  ADD KEY `distributorId` (`distributorId`),
  ADD KEY `providerId` (`providerId`);

--
-- Indices de la tabla `sisg_serialsreplacements`
--
ALTER TABLE `sisg_serialsreplacements`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `serial` (`serial`),
  ADD KEY `replacementId` (`replacementId`),
  ADD KEY `distributorId` (`distributorId`),
  ADD KEY `providerId` (`providerId`);

--
-- Indices de la tabla `sisg_states`
--
ALTER TABLE `sisg_states`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_statesorder`
--
ALTER TABLE `sisg_statesorder`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_technicalsoperations`
--
ALTER TABLE `sisg_technicalsoperations`
  ADD PRIMARY KEY (`id`),
  ADD KEY `finalClientId` (`finalClientId`),
  ADD KEY `technicianId` (`technicianId`),
  ADD KEY `providerId` (`providerId`),
  ADD KEY `typeOperationTechId` (`typeOperationTechId`),
  ADD KEY `distributorId` (`distributorId`);

--
-- Indices de la tabla `sisg_technicians`
--
ALTER TABLE `sisg_technicians`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `rif` (`rif`);

--
-- Indices de la tabla `sisg_techniciansdistributors`
--
ALTER TABLE `sisg_techniciansdistributors`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `techniciansId_2` (`techniciansId`,`distributorsId`),
  ADD KEY `techniciansId` (`techniciansId`),
  ADD KEY `distributorsId` (`distributorsId`);

--
-- Indices de la tabla `sisg_techniciansusers`
--
ALTER TABLE `sisg_techniciansusers`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `techniciansId_2` (`techniciansId`,`userId`),
  ADD KEY `techniciansId` (`techniciansId`),
  ADD KEY `userId` (`userId`);

--
-- Indices de la tabla `sisg_typeoperationstechs`
--
ALTER TABLE `sisg_typeoperationstechs`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_typesfailures`
--
ALTER TABLE `sisg_typesfailures`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sisg_users`
--
ALTER TABLE `sisg_users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD KEY `rolId` (`rolId`);

--
-- Indices de la tabla `sisg_workshopbinnacles`
--
ALTER TABLE `sisg_workshopbinnacles`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `orderId` (`orderId`,`statusId`,`userId`),
  ADD KEY `statusId` (`statusId`),
  ADD KEY `userId` (`userId`);

--
-- Indices de la tabla `sisg_workshoporders`
--
ALTER TABLE `sisg_workshoporders`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `numerOrder` (`numerOrder`),
  ADD KEY `distributorId` (`distributorId`),
  ADD KEY `typeFailurId` (`typeFailurId`),
  ADD KEY `stateOrderId` (`stateOrderId`),
  ADD KEY `deliveryOrderId` (`deliveryOrderId`),
  ADD KEY `employeeId` (`employeeId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `sisg_accessories`
--
ALTER TABLE `sisg_accessories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `sisg_accessoriesorders`
--
ALTER TABLE `sisg_accessoriesorders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT de la tabla `sisg_accessroles`
--
ALTER TABLE `sisg_accessroles`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `sisg_activities`
--
ALTER TABLE `sisg_activities`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=72;

--
-- AUTO_INCREMENT de la tabla `sisg_alienations`
--
ALTER TABLE `sisg_alienations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `sisg_categories`
--
ALTER TABLE `sisg_categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de la tabla `sisg_chargues`
--
ALTER TABLE `sisg_chargues`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT de la tabla `sisg_countries`
--
ALTER TABLE `sisg_countries`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=241;

--
-- AUTO_INCREMENT de la tabla `sisg_deliveryorder`
--
ALTER TABLE `sisg_deliveryorder`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT de la tabla `sisg_departaments`
--
ALTER TABLE `sisg_departaments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de la tabla `sisg_developersclients`
--
ALTER TABLE `sisg_developersclients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `sisg_developersclientsusers`
--
ALTER TABLE `sisg_developersclientsusers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `sisg_distributors`
--
ALTER TABLE `sisg_distributors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT de la tabla `sisg_distributorsproviders`
--
ALTER TABLE `sisg_distributorsproviders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT de la tabla `sisg_distributorsusers`
--
ALTER TABLE `sisg_distributorsusers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT de la tabla `sisg_employees`
--
ALTER TABLE `sisg_employees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de la tabla `sisg_employeesusers`
--
ALTER TABLE `sisg_employeesusers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de la tabla `sisg_finalsclients`
--
ALTER TABLE `sisg_finalsclients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1762;

--
-- AUTO_INCREMENT de la tabla `sisg_finalsclientsusers`
--
ALTER TABLE `sisg_finalsclientsusers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `sisg_fiscalsoperations`
--
ALTER TABLE `sisg_fiscalsoperations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT de la tabla `sisg_marks`
--
ALTER TABLE `sisg_marks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de la tabla `sisg_menus`
--
ALTER TABLE `sisg_menus`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT de la tabla `sisg_models`
--
ALTER TABLE `sisg_models`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `sisg_photographsorder`
--
ALTER TABLE `sisg_photographsorder`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `sisg_prefixes`
--
ALTER TABLE `sisg_prefixes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de la tabla `sisg_products`
--
ALTER TABLE `sisg_products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `sisg_productsaccessories`
--
ALTER TABLE `sisg_productsaccessories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `sisg_productsreplacements`
--
ALTER TABLE `sisg_productsreplacements`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `sisg_profiles`
--
ALTER TABLE `sisg_profiles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `sisg_providers`
--
ALTER TABLE `sisg_providers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `sisg_replacements`
--
ALTER TABLE `sisg_replacements`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de la tabla `sisg_replacementsopetechs`
--
ALTER TABLE `sisg_replacementsopetechs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `sisg_replacementsorders`
--
ALTER TABLE `sisg_replacementsorders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `sisg_roles`
--
ALTER TABLE `sisg_roles`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `sisg_rolesmenus`
--
ALTER TABLE `sisg_rolesmenus`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=107;

--
-- AUTO_INCREMENT de la tabla `sisg_serialsproducts`
--
ALTER TABLE `sisg_serialsproducts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=118;

--
-- AUTO_INCREMENT de la tabla `sisg_serialsreplacements`
--
ALTER TABLE `sisg_serialsreplacements`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT de la tabla `sisg_states`
--
ALTER TABLE `sisg_states`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT de la tabla `sisg_statesorder`
--
ALTER TABLE `sisg_statesorder`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `sisg_technicalsoperations`
--
ALTER TABLE `sisg_technicalsoperations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de la tabla `sisg_technicians`
--
ALTER TABLE `sisg_technicians`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `sisg_techniciansdistributors`
--
ALTER TABLE `sisg_techniciansdistributors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de la tabla `sisg_techniciansusers`
--
ALTER TABLE `sisg_techniciansusers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `sisg_typeoperationstechs`
--
ALTER TABLE `sisg_typeoperationstechs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `sisg_typesfailures`
--
ALTER TABLE `sisg_typesfailures`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT de la tabla `sisg_users`
--
ALTER TABLE `sisg_users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=79;

--
-- AUTO_INCREMENT de la tabla `sisg_workshopbinnacles`
--
ALTER TABLE `sisg_workshopbinnacles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `sisg_workshoporders`
--
ALTER TABLE `sisg_workshoporders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `sisg_accessoriesorders`
--
ALTER TABLE `sisg_accessoriesorders`
  ADD CONSTRAINT `sisg_accessoriesorders_ibfk_1` FOREIGN KEY (`orderId`) REFERENCES `sisg_workshoporders` (`id`),
  ADD CONSTRAINT `sisg_accessoriesorders_ibfk_2` FOREIGN KEY (`accesoryId`) REFERENCES `sisg_accessories` (`id`);

--
-- Filtros para la tabla `sisg_activities`
--
ALTER TABLE `sisg_activities`
  ADD CONSTRAINT `sisg_activities_ibfk_1` FOREIGN KEY (`employeeId`) REFERENCES `sisg_employees` (`id`);

--
-- Filtros para la tabla `sisg_alienations`
--
ALTER TABLE `sisg_alienations`
  ADD CONSTRAINT `sisg_alienations_ibfk_1` FOREIGN KEY (`providerId`) REFERENCES `sisg_providers` (`id`),
  ADD CONSTRAINT `sisg_alienations_ibfk_2` FOREIGN KEY (`distributorId`) REFERENCES `sisg_distributors` (`id`),
  ADD CONSTRAINT `sisg_alienations_ibfk_3` FOREIGN KEY (`finalclientId`) REFERENCES `sisg_finalsclients` (`id`);

--
-- Filtros para la tabla `sisg_chargues`
--
ALTER TABLE `sisg_chargues`
  ADD CONSTRAINT `sisg_chargues_ibfk_1` FOREIGN KEY (`rolId`) REFERENCES `sisg_roles` (`id`);

--
-- Filtros para la tabla `sisg_developersclientsusers`
--
ALTER TABLE `sisg_developersclientsusers`
  ADD CONSTRAINT `sisg_developersclientsusers_ibfk_1` FOREIGN KEY (`developersclientsId`) REFERENCES `sisg_developersclients` (`id`),
  ADD CONSTRAINT `sisg_developersclientsusers_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `sisg_users` (`id`);

--
-- Filtros para la tabla `sisg_distributorsproviders`
--
ALTER TABLE `sisg_distributorsproviders`
  ADD CONSTRAINT `sisg_distributorsproviders_ibfk_1` FOREIGN KEY (`providerId`) REFERENCES `sisg_providers` (`id`),
  ADD CONSTRAINT `sisg_distributorsproviders_ibfk_2` FOREIGN KEY (`distributorsId`) REFERENCES `sisg_distributors` (`id`);

--
-- Filtros para la tabla `sisg_distributorsusers`
--
ALTER TABLE `sisg_distributorsusers`
  ADD CONSTRAINT `sisg_distributorsusers_ibfk_1` FOREIGN KEY (`distributorsId`) REFERENCES `sisg_distributors` (`id`),
  ADD CONSTRAINT `sisg_distributorsusers_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `sisg_users` (`id`);

--
-- Filtros para la tabla `sisg_employees`
--
ALTER TABLE `sisg_employees`
  ADD CONSTRAINT `sisg_employees_ibfk_1` FOREIGN KEY (`departamentId`) REFERENCES `sisg_departaments` (`id`),
  ADD CONSTRAINT `sisg_employees_ibfk_2` FOREIGN KEY (`chargueId`) REFERENCES `sisg_chargues` (`id`);

--
-- Filtros para la tabla `sisg_employeesusers`
--
ALTER TABLE `sisg_employeesusers`
  ADD CONSTRAINT `sisg_employeesusers_ibfk_1` FOREIGN KEY (`employeeId`) REFERENCES `sisg_employees` (`id`),
  ADD CONSTRAINT `sisg_employeesusers_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `sisg_users` (`id`);

--
-- Filtros para la tabla `sisg_fiscalsoperations`
--
ALTER TABLE `sisg_fiscalsoperations`
  ADD CONSTRAINT `sisg_fiscalsoperations_ibfk_0` FOREIGN KEY (`providerId`) REFERENCES `sisg_providers` (`id`),
  ADD CONSTRAINT `sisg_fiscalsoperations_ibfk_1` FOREIGN KEY (`technicianId`) REFERENCES `sisg_technicians` (`id`),
  ADD CONSTRAINT `sisg_fiscalsoperations_ibfk_2` FOREIGN KEY (`distributorId`) REFERENCES `sisg_distributors` (`id`),
  ADD CONSTRAINT `sisg_fiscalsoperations_ibfk_3` FOREIGN KEY (`finalClientId`) REFERENCES `sisg_finalsclients` (`id`);

--
-- Filtros para la tabla `sisg_models`
--
ALTER TABLE `sisg_models`
  ADD CONSTRAINT `sisg_models_ibfk_1` FOREIGN KEY (`markId`) REFERENCES `sisg_marks` (`id`);

--
-- Filtros para la tabla `sisg_products`
--
ALTER TABLE `sisg_products`
  ADD CONSTRAINT `sisg_products_ibfk_1` FOREIGN KEY (`categoryId`) REFERENCES `sisg_categories` (`id`),
  ADD CONSTRAINT `sisg_products_ibfk_2` FOREIGN KEY (`modelId`) REFERENCES `sisg_models` (`id`);

--
-- Filtros para la tabla `sisg_productsaccessories`
--
ALTER TABLE `sisg_productsaccessories`
  ADD CONSTRAINT `sisg_productsaccessories_ibfk_1` FOREIGN KEY (`productId`) REFERENCES `sisg_products` (`id`),
  ADD CONSTRAINT `sisg_productsaccessories_ibfk_2` FOREIGN KEY (`accessoryId`) REFERENCES `sisg_accessories` (`id`);

--
-- Filtros para la tabla `sisg_productsreplacements`
--
ALTER TABLE `sisg_productsreplacements`
  ADD CONSTRAINT `sisg_productsreplacements_ibfk_1` FOREIGN KEY (`productId`) REFERENCES `sisg_products` (`id`),
  ADD CONSTRAINT `sisg_productsreplacements_ibfk_2` FOREIGN KEY (`replacementId`) REFERENCES `sisg_replacements` (`id`);

--
-- Filtros para la tabla `sisg_replacements`
--
ALTER TABLE `sisg_replacements`
  ADD CONSTRAINT `sisg_replacements_ibfk_1` FOREIGN KEY (`modelId`) REFERENCES `sisg_models` (`id`);

--
-- Filtros para la tabla `sisg_replacementsopetechs`
--
ALTER TABLE `sisg_replacementsopetechs`
  ADD CONSTRAINT `sisg_replacementsopetechs_ibfk_1` FOREIGN KEY (`operationTechId`) REFERENCES `sisg_technicalsoperations` (`id`),
  ADD CONSTRAINT `sisg_replacementsopetechs_ibfk_2` FOREIGN KEY (`replacementId`) REFERENCES `sisg_replacements` (`id`);

--
-- Filtros para la tabla `sisg_roles`
--
ALTER TABLE `sisg_roles`
  ADD CONSTRAINT `sisg_roles_ibfk_1` FOREIGN KEY (`accessId`) REFERENCES `sisg_accessroles` (`id`),
  ADD CONSTRAINT `sisg_roles_ibfk_2` FOREIGN KEY (`profileId`) REFERENCES `sisg_profiles` (`id`);

--
-- Filtros para la tabla `sisg_rolesmenus`
--
ALTER TABLE `sisg_rolesmenus`
  ADD CONSTRAINT `sisg_rolesmenus_ibfk_1` FOREIGN KEY (`MenuId`) REFERENCES `sisg_menus` (`id`),
  ADD CONSTRAINT `sisg_rolesmenus_ibfk_2` FOREIGN KEY (`RolId`) REFERENCES `sisg_roles` (`id`);

--
-- Filtros para la tabla `sisg_serialsproducts`
--
ALTER TABLE `sisg_serialsproducts`
  ADD CONSTRAINT `sisg_serialsproducts_ibfk_1` FOREIGN KEY (`productId`) REFERENCES `sisg_products` (`id`),
  ADD CONSTRAINT `sisg_serialsproducts_ibfk_2` FOREIGN KEY (`providerId`) REFERENCES `sisg_providers` (`id`),
  ADD CONSTRAINT `sisg_serialsproducts_ibfk_3` FOREIGN KEY (`distributorId`) REFERENCES `sisg_distributors` (`id`);

--
-- Filtros para la tabla `sisg_serialsreplacements`
--
ALTER TABLE `sisg_serialsreplacements`
  ADD CONSTRAINT `sisg_serialsreplacements_ibfk_1` FOREIGN KEY (`replacementId`) REFERENCES `sisg_replacements` (`id`),
  ADD CONSTRAINT `sisg_serialsreplacements_ibfk_2` FOREIGN KEY (`providerId`) REFERENCES `sisg_providers` (`id`),
  ADD CONSTRAINT `sisg_serialsreplacements_ibfk_3` FOREIGN KEY (`distributorId`) REFERENCES `sisg_distributors` (`id`);

--
-- Filtros para la tabla `sisg_technicalsoperations`
--
ALTER TABLE `sisg_technicalsoperations`
  ADD CONSTRAINT `sisg_technicalsoperations_ibfk_1` FOREIGN KEY (`distributorId`) REFERENCES `sisg_distributors` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `sisg_technicalsoperations_ibfk_2` FOREIGN KEY (`technicianId`) REFERENCES `sisg_technicians` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `sisg_technicalsoperations_ibfk_3` FOREIGN KEY (`finalClientId`) REFERENCES `sisg_finalsclients` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `sisg_technicalsoperations_ibfk_4` FOREIGN KEY (`providerId`) REFERENCES `sisg_providers` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `sisg_technicalsoperations_ibfk_5` FOREIGN KEY (`typeOperationTechId`) REFERENCES `sisg_typeoperationstechs` (`id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `sisg_techniciansdistributors`
--
ALTER TABLE `sisg_techniciansdistributors`
  ADD CONSTRAINT `sisg_techniciansdistributors_ibfk_1` FOREIGN KEY (`techniciansId`) REFERENCES `sisg_technicians` (`id`),
  ADD CONSTRAINT `sisg_techniciansdistributors_ibfk_2` FOREIGN KEY (`distributorsId`) REFERENCES `sisg_distributors` (`id`);

--
-- Filtros para la tabla `sisg_techniciansusers`
--
ALTER TABLE `sisg_techniciansusers`
  ADD CONSTRAINT `sisg_techniciansusers_ibfk_1` FOREIGN KEY (`techniciansId`) REFERENCES `sisg_technicians` (`id`),
  ADD CONSTRAINT `sisg_techniciansusers_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `sisg_users` (`id`);

--
-- Filtros para la tabla `sisg_users`
--
ALTER TABLE `sisg_users`
  ADD CONSTRAINT `sisg_users_ibfk_1` FOREIGN KEY (`rolId`) REFERENCES `sisg_roles` (`id`);

--
-- Filtros para la tabla `sisg_workshopbinnacles`
--
ALTER TABLE `sisg_workshopbinnacles`
  ADD CONSTRAINT `sisg_workshopbinnacles_ibfk_3` FOREIGN KEY (`orderId`) REFERENCES `sisg_workshoporders` (`id`),
  ADD CONSTRAINT `sisg_workshopbinnacles_ibfk_4` FOREIGN KEY (`statusId`) REFERENCES `sisg_statesorder` (`id`),
  ADD CONSTRAINT `sisg_workshopbinnacles_ibfk_5` FOREIGN KEY (`userId`) REFERENCES `sisg_employees` (`id`);

--
-- Filtros para la tabla `sisg_workshoporders`
--
ALTER TABLE `sisg_workshoporders`
  ADD CONSTRAINT `sisg_workshoporders_ibfk_1` FOREIGN KEY (`typeFailurId`) REFERENCES `sisg_typesfailures` (`id`),
  ADD CONSTRAINT `sisg_workshoporders_ibfk_2` FOREIGN KEY (`stateOrderId`) REFERENCES `sisg_statesorder` (`id`),
  ADD CONSTRAINT `sisg_workshoporders_ibfk_4` FOREIGN KEY (`deliveryOrderId`) REFERENCES `sisg_deliveryorder` (`id`),
  ADD CONSTRAINT `sisg_workshoporders_ibfk_5` FOREIGN KEY (`employeeId`) REFERENCES `sisg_employees` (`id`),
  ADD CONSTRAINT `sisg_workshoporders_ibfk_6` FOREIGN KEY (`distributorId`) REFERENCES `sisg_distributors` (`id`);

DELIMITER $$
--
-- Eventos
--
CREATE DEFINER=`root`@`localhost` EVENT `event_ExpirationDate` ON SCHEDULE EVERY 1 DAY STARTS '2020-10-08 12:10:00' ON COMPLETION NOT PRESERVE ENABLE DO Update sisg_workshoporders set stateOrderId = 12 where 
(stateOrderId = 1 OR stateOrderId = 2)   
AND DATE_FORMAT(expirationDate,'%y-%m-%d') = CURDATE()$$

DELIMITER ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
