CREATE TABLE benchmarkedresolution (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    PixelWidth integer NOT NULL,
    PixelHeight integer NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT benchmarkedresolution_pixelarea_unique UNIQUE (PixelWidth, PixelHeight),
    CONSTRAINT benchmarkedresolution_pixelwidth_range CHECK (PixelWidth > 0 AND PixelWidth <= 15360),
    CONSTRAINT benchmarkedresolution_pixelheight_range CHECK (PixelHeight > 0 AND PixelHeight <= 8640)
);