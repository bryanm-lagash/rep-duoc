USE OnTour 
CREATE TABLE actividad (
    idactividad   [int] NOT NULL,
    nombre        [nvarchar](30) NOT NULL,
    costo         [int] NOT NULL
);

ALTER TABLE actividad ADD CONSTRAINT actividad_pk PRIMARY KEY ( idactividad );

CREATE TABLE alumno (
    rutalumno       [nvarchar](11) NOT NULL,
    nombre          [nvarchar](50) NOT NULL,
    apaterno        [nvarchar](50) NOT NULL,
    amaterno        [nvarchar](50) NOT NULL,
    direccion       [nvarchar](70) NOT NULL,
    curso_idcurso   [nvarchar](10) NOT NULL
);

ALTER TABLE alumno ADD CONSTRAINT alumno_pk PRIMARY KEY ( rutalumno );

CREATE TABLE beneficio (
    idbenefico      [int] NOT NULL,
    nombre          [nvarchar](30) NOT NULL,
    porcdescuento   [int] NOT NULL
);

ALTER TABLE beneficio ADD CONSTRAINT beneficio_pk PRIMARY KEY ( idbenefico );

CREATE TABLE ciudad (
    codciudad      [int] NOT NULL,
    nombre         [nvarchar](20) NOT NULL,
    pais_codpais   [int] NOT NULL
);

ALTER TABLE ciudad ADD CONSTRAINT ciudad_pk PRIMARY KEY ( codciudad );

CREATE TABLE colegio (
    codcolegio       [nvarchar](10) NOT NULL,
    nombre           [nvarchar](50) NOT NULL,
    direccion        [nvarchar](50) NOT NULL,
    tipcole_idtipo   [int] NOT NULL
);

ALTER TABLE colegio ADD CONSTRAINT colegio_pk PRIMARY KEY ( codcolegio );

CREATE TABLE contrato (
    numcontrato              [int] NOT NULL,
    fechacreacion            DATE NOT NULL,
    fechatermino             DATE NOT NULL,
    duraciondias             [int] NOT NULL,
    fechaini                 DATE NOT NULL,
    fechaterm                DATE NOT NULL,
    fechapagos               [nvarchar](30) NOT NULL,
    costototseguros          [int] NOT NULL,
    costototactividades      [int] NOT NULL,
    porctotbeneficios        [int] NOT NULL,
    costoservicios           [int] NOT NULL,
    meta                     [int] NOT NULL,
    tipactividad_idtipoact   [int] NOT NULL,
    curso_idcurso            [nvarchar](10) NOT NULL,
    ciudad_codciudad         [int] NOT NULL,
    usuario_rutusu           [nvarchar](11) NOT NULL
);

ALTER TABLE contrato ADD CONSTRAINT contrato_pk PRIMARY KEY ( numcontrato );

CREATE TABLE cta_usuario (
    usuario               [nvarchar](20) NOT NULL,
    contraseña            [nvarchar](20) NOT NULL,
    nombre                [nvarchar](25) NOT NULL,
    usuario_rutusu        [nvarchar](11) NOT NULL,
    tipcuenta_idtipocta   [int] NOT NULL
);

ALTER TABLE cta_usuario ADD CONSTRAINT cta_usuario_pk PRIMARY KEY ( usuario );

CREATE TABLE curso (
    idcurso              [nvarchar](10) NOT NULL,
    numalumnos           [int] NOT NULL,
    colegio_codcolegio   [nvarchar](10) NOT NULL
);

ALTER TABLE curso ADD CONSTRAINT curso_pk PRIMARY KEY ( idcurso );

CREATE TABLE deposito (
    iddeposito      [int] NOT NULL,
    fechadeposito   DATE NOT NULL,
    montodeposito   [int] NOT NULL,
    curso_idcurso   [nvarchar](10) NOT NULL,
    rutdepos        [nvarchar](11) NOT NULL,
    nombredepos     [nvarchar](40) NOT NULL
);

ALTER TABLE deposito ADD CONSTRAINT deposito_pk PRIMARY KEY ( iddeposito );

CREATE TABLE detalle_actividad (
    iddetact                [int] NOT NULL,
    cant_actividades        [int] NOT NULL,
    actividad_idactividad   [int] NOT NULL,
    contrato_numcontrato    [int] NOT NULL
);

ALTER TABLE detalle_actividad ADD CONSTRAINT detalle_actividad_pk PRIMARY KEY ( iddetact );

CREATE TABLE detalle_beneficio (
    iddetben               [int] NOT NULL,
    cant_beneficios        [int] NOT NULL,
    beneficio_idbenefico   [int] NOT NULL,
    contrato_numcontrato   [int] NOT NULL
);

ALTER TABLE detalle_beneficio ADD CONSTRAINT detalle_beneficio_pk PRIMARY KEY ( iddetben );

CREATE TABLE detalle_seguro (
    iddetseg               [int] NOT NULL,
    cant_seguros           [int] NOT NULL,
    seguro_idseguro        [int] NOT NULL,
    contrato_numcontrato   [int] NOT NULL
);

ALTER TABLE detalle_seguro ADD CONSTRAINT detalle_seguro_pk PRIMARY KEY ( iddetseg );

CREATE TABLE empaseg (
    rutemp      [nvarchar](11) NOT NULL,
    nombre      [nvarchar](30) NOT NULL,
    direccion   [nvarchar](30) NOT NULL,
    telefono    [int] NOT NULL
);

ALTER TABLE empaseg ADD CONSTRAINT empaseg_pk PRIMARY KEY ( rutemp );

CREATE TABLE modaporte (
    idmod    [int] NOT NULL,
    nombre   [nvarchar](20) NOT NULL
);

ALTER TABLE modaporte ADD CONSTRAINT modaporte_pk PRIMARY KEY ( idmod );

CREATE TABLE pais (
    codpais   [int] NOT NULL,
    nombre    [nvarchar](20) NOT NULL
);

ALTER TABLE pais ADD CONSTRAINT pais_pk PRIMARY KEY ( codpais );

CREATE TABLE seguro (
    idseguro         [int] NOT NULL,
    nombre           [nvarchar](30) NOT NULL,
    descripcion      [nvarchar](70) NOT NULL,
    costo            [int] NOT NULL,
    empaseg_rutemp   [nvarchar](11) NOT NULL
);

ALTER TABLE seguro ADD CONSTRAINT seguro_pk PRIMARY KEY ( idseguro );

CREATE TABLE tasa_interes (
    idinteres   [int] NOT NULL,
    diasini     [int] NOT NULL,
    diasterm    [int] NOT NULL,
    porcmulta   [int] NOT NULL
);

ALTER TABLE tasa_interes ADD CONSTRAINT tasa_interes_pk PRIMARY KEY ( idinteres );

CREATE TABLE tipactividad (
    idtipoact         [int] NOT NULL,
    nombre            [nvarchar](30) NOT NULL,
    modaporte_idmod   [int] NOT NULL
);

ALTER TABLE tipactividad ADD CONSTRAINT tipactividad_pk PRIMARY KEY ( idtipoact );

CREATE TABLE tipcole (
    idtipo   [int] NOT NULL,
    nombre   [nvarchar](30) NOT NULL
);

ALTER TABLE tipcole ADD CONSTRAINT tipcole_pk PRIMARY KEY ( idtipo );

CREATE TABLE tipcuenta (
    idtipocta   [int] NOT NULL,
    nombre      [nvarchar](50) NOT NULL
);

ALTER TABLE tipcuenta ADD CONSTRAINT tipcuenta_pk PRIMARY KEY ( idtipocta );

CREATE TABLE usuario (
    rutusu      [nvarchar](11) NOT NULL,
    nombre      [nvarchar](40) NOT NULL,
    apaterno    [nvarchar](40) NOT NULL,
    amaterno    [nvarchar](40) NOT NULL,
    direccion   [nvarchar](40) NOT NULL,
    email       [nvarchar](40) NOT NULL
);

ALTER TABLE usuario ADD CONSTRAINT usuario_pk PRIMARY KEY ( rutusu );

ALTER TABLE alumno
    ADD CONSTRAINT alumno_curso_fk FOREIGN KEY ( curso_idcurso )
        REFERENCES curso ( idcurso );

ALTER TABLE ciudad
    ADD CONSTRAINT ciudad_pais_fk FOREIGN KEY ( pais_codpais )
        REFERENCES pais ( codpais );

ALTER TABLE colegio
    ADD CONSTRAINT colegio_tipcole_fk FOREIGN KEY ( tipcole_idtipo )
        REFERENCES tipcole ( idtipo );

ALTER TABLE contrato
    ADD CONSTRAINT contrato_ciudad_fk FOREIGN KEY ( ciudad_codciudad )
        REFERENCES ciudad ( codciudad );

ALTER TABLE contrato
    ADD CONSTRAINT contrato_curso_fk FOREIGN KEY ( curso_idcurso )
        REFERENCES curso ( idcurso );

ALTER TABLE contrato
    ADD CONSTRAINT contrato_tipactividad_fk FOREIGN KEY ( tipactividad_idtipoact )
        REFERENCES tipactividad ( idtipoact );

ALTER TABLE contrato
    ADD CONSTRAINT contrato_usuario_fk FOREIGN KEY ( usuario_rutusu )
        REFERENCES usuario ( rutusu );

ALTER TABLE cta_usuario
    ADD CONSTRAINT cta_usuario_tipcuenta_fk FOREIGN KEY ( tipcuenta_idtipocta )
        REFERENCES tipcuenta ( idtipocta );

ALTER TABLE cta_usuario
    ADD CONSTRAINT cta_usuario_usuario_fk FOREIGN KEY ( usuario_rutusu )
        REFERENCES usuario ( rutusu );

ALTER TABLE curso
    ADD CONSTRAINT curso_colegio_fk FOREIGN KEY ( colegio_codcolegio )
        REFERENCES colegio ( codcolegio );

ALTER TABLE deposito
    ADD CONSTRAINT deposito_curso_fk FOREIGN KEY ( curso_idcurso )
        REFERENCES curso ( idcurso );

ALTER TABLE detalle_actividad
    ADD CONSTRAINT detalle_actividad_actividad_fk FOREIGN KEY ( actividad_idactividad )
        REFERENCES actividad ( idactividad );

ALTER TABLE detalle_actividad
    ADD CONSTRAINT detalle_actividad_contrato_fk FOREIGN KEY ( contrato_numcontrato )
        REFERENCES contrato ( numcontrato );

ALTER TABLE detalle_beneficio
    ADD CONSTRAINT detalle_beneficio_beneficio_fk FOREIGN KEY ( beneficio_idbenefico )
        REFERENCES beneficio ( idbenefico );

ALTER TABLE detalle_beneficio
    ADD CONSTRAINT detalle_beneficio_contrato_fk FOREIGN KEY ( contrato_numcontrato )
        REFERENCES contrato ( numcontrato );

ALTER TABLE detalle_seguro
    ADD CONSTRAINT detalle_seguro_contrato_fk FOREIGN KEY ( contrato_numcontrato )
        REFERENCES contrato ( numcontrato );

ALTER TABLE detalle_seguro
    ADD CONSTRAINT detalle_seguro_seguro_fk FOREIGN KEY ( seguro_idseguro )
        REFERENCES seguro ( idseguro );

ALTER TABLE seguro
    ADD CONSTRAINT seguro_empaseg_fk FOREIGN KEY ( empaseg_rutemp )
        REFERENCES empaseg ( rutemp );

ALTER TABLE tipactividad
    ADD CONSTRAINT tipactividad_modaporte_fk FOREIGN KEY ( modaporte_idmod )
        REFERENCES modaporte ( idmod );
