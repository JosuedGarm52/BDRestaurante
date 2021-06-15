-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 29-05-2021 a las 05:42:30
-- Versión del servidor: 10.4.18-MariaDB
-- Versión de PHP: 8.0.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `restaurante`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

CREATE TABLE `categoria` (
  `id_categoria` varchar(20) NOT NULL,
  `id_plato` varchar(20) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `id_encargado` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `categoria`
--

INSERT INTO `categoria` (`id_categoria`, `id_plato`, `descripcion`, `id_encargado`) VALUES
('CAT-01', 'PLAT30', 'P. pato y naranja', 'ENC12');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `encargado`
--

CREATE TABLE `encargado` (
  `id_encargado` varchar(20) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `encargado`
--

INSERT INTO `encargado` (`id_encargado`, `nombre`, `apellido`) VALUES
('ENC12', 'Jose', 'Gamez'),
('ENC31', 'Juan ', 'Gomez');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ingred`
--

CREATE TABLE `ingred` (
  `id_ingrediente` varchar(20) NOT NULL,
  `ingrediente` varchar(50) NOT NULL,
  `almacen` varchar(50) NOT NULL,
  `unidades` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ingred`
--

INSERT INTO `ingred` (`id_ingrediente`, `ingrediente`, `almacen`, `unidades`) VALUES
('ING1', 'pato', 'centro', 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `platillo`
--

CREATE TABLE `platillo` (
  `id_platillo` varchar(20) NOT NULL,
  `id_plato` varchar(20) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `nivel` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `platillo`
--

INSERT INTO `platillo` (`id_platillo`, `id_plato`, `descripcion`, `nivel`) VALUES
('P100', 'PLAT30', 'Platilo de pato asado', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `plato`
--

CREATE TABLE `plato` (
  `id_plato` varchar(20) NOT NULL,
  `Foto` longblob DEFAULT NULL,
  `precio` double(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `plato`
--

INSERT INTO `plato` (`id_plato`, `Foto`, `precio`) VALUES
('PLAT30', NULL, 30000),
('PLAT31', NULL, 40000),
('PLAT32', NULL, 60000),
('PLAT33', NULL, 70000),
('PLAT34', NULL, 50000),
('PLAT35', NULL, 30000),
('PLAT36', NULL, 40000),
('PLAT37', NULL, 50000),
('PLAT38', NULL, 60000),
('PLAT39', NULL, 70000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `utiliza`
--

CREATE TABLE `utiliza` (
  `id_plato` varchar(20) NOT NULL,
  `id_ingrediente` varchar(20) NOT NULL,
  `cantidad` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `utiliza`
--

INSERT INTO `utiliza` (`id_plato`, `id_ingrediente`, `cantidad`) VALUES
('PLAT30', 'ING1', 2);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`id_categoria`,`id_plato`,`id_encargado`),
  ADD KEY `id_encargado` (`id_encargado`),
  ADD KEY `id_plato` (`id_plato`);

--
-- Indices de la tabla `encargado`
--
ALTER TABLE `encargado`
  ADD PRIMARY KEY (`id_encargado`);

--
-- Indices de la tabla `ingred`
--
ALTER TABLE `ingred`
  ADD PRIMARY KEY (`id_ingrediente`);

--
-- Indices de la tabla `platillo`
--
ALTER TABLE `platillo`
  ADD PRIMARY KEY (`id_platillo`,`id_plato`),
  ADD KEY `id_plato` (`id_plato`);

--
-- Indices de la tabla `plato`
--
ALTER TABLE `plato`
  ADD PRIMARY KEY (`id_plato`);

--
-- Indices de la tabla `utiliza`
--
ALTER TABLE `utiliza`
  ADD PRIMARY KEY (`id_plato`,`id_ingrediente`),
  ADD KEY `id_ingrediente` (`id_ingrediente`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD CONSTRAINT `categoria_ibfk_1` FOREIGN KEY (`id_encargado`) REFERENCES `encargado` (`id_encargado`),
  ADD CONSTRAINT `categoria_ibfk_2` FOREIGN KEY (`id_plato`) REFERENCES `plato` (`id_plato`);

--
-- Filtros para la tabla `platillo`
--
ALTER TABLE `platillo`
  ADD CONSTRAINT `platillo_ibfk_1` FOREIGN KEY (`id_plato`) REFERENCES `plato` (`id_plato`);

--
-- Filtros para la tabla `utiliza`
--
ALTER TABLE `utiliza`
  ADD CONSTRAINT `utiliza_ibfk_1` FOREIGN KEY (`id_plato`) REFERENCES `plato` (`id_plato`),
  ADD CONSTRAINT `utiliza_ibfk_2` FOREIGN KEY (`id_ingrediente`) REFERENCES `ingred` (`id_ingrediente`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
