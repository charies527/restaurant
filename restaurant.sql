

SET SERVEROUTPUT ON;

PROMPT ==========================================
PROMPT RestaurantSystem 테이블 확인 및 생성
PROMPT ==========================================

DECLARE
    v_count NUMBER;
BEGIN
    -- MENU
    SELECT COUNT(*) INTO v_count
      FROM USER_TABLES
     WHERE TABLE_NAME = 'MENU';

    IF v_count = 0 THEN
        EXECUTE IMMEDIATE '
            CREATE TABLE MENU (
                MENU_ID   VARCHAR2(10) PRIMARY KEY,
                MENU_NAME VARCHAR2(50) NOT NULL,
                PRICE     NUMBER NOT NULL,
                STATUS    VARCHAR2(20) DEFAULT ''판매중''
            )';
        DBMS_OUTPUT.PUT_LINE('MENU 테이블 생성 완료');
    ELSE
        DBMS_OUTPUT.PUT_LINE('MENU 테이블 이미 존재 - 유지');
    END IF;

    -- INGREDIENT
    SELECT COUNT(*) INTO v_count
      FROM USER_TABLES
     WHERE TABLE_NAME = 'INGREDIENT';

    IF v_count = 0 THEN
        EXECUTE IMMEDIATE '
            CREATE TABLE INGREDIENT (
                ING_ID      VARCHAR2(10) PRIMARY KEY,
                ING_NAME    VARCHAR2(50) NOT NULL,
                CURRENT_QTY NUMBER NOT NULL,
                MIN_QTY     NUMBER NOT NULL,
                UNIT        VARCHAR2(10) DEFAULT ''kg''
            )';
        DBMS_OUTPUT.PUT_LINE('INGREDIENT 테이블 생성 완료');
    ELSE
        DBMS_OUTPUT.PUT_LINE('INGREDIENT 테이블 이미 존재 - 유지');
    END IF;

    -- MENU_INGREDIENT
    SELECT COUNT(*) INTO v_count
      FROM USER_TABLES
     WHERE TABLE_NAME = 'MENU_INGREDIENT';

    IF v_count = 0 THEN
        EXECUTE IMMEDIATE '
            CREATE TABLE MENU_INGREDIENT (
                MENU_ID VARCHAR2(10),
                ING_ID  VARCHAR2(10),
                USE_QTY NUMBER NOT NULL,
                CONSTRAINT PK_MENU_INGREDIENT PRIMARY KEY (MENU_ID, ING_ID),
                CONSTRAINT FK_MI_MENU FOREIGN KEY (MENU_ID)
                    REFERENCES MENU(MENU_ID),
                CONSTRAINT FK_MI_ING FOREIGN KEY (ING_ID)
                    REFERENCES INGREDIENT(ING_ID)
            )';
        DBMS_OUTPUT.PUT_LINE('MENU_INGREDIENT 테이블 생성 완료');
    ELSE
        DBMS_OUTPUT.PUT_LINE('MENU_INGREDIENT 테이블 이미 존재 - 유지');
    END IF;

    -- ORDERS
    SELECT COUNT(*) INTO v_count
      FROM USER_TABLES
     WHERE TABLE_NAME = 'ORDERS';

    IF v_count = 0 THEN
        EXECUTE IMMEDIATE '
            CREATE TABLE ORDERS (
                ORDER_ID      NUMBER PRIMARY KEY,
                CUSTOMER_NAME VARCHAR2(50),
                ORDER_DT      VARCHAR2(20),
                TOTAL_AMT     NUMBER,
                STATUS        VARCHAR2(20) DEFAULT ''등록''
            )';
        DBMS_OUTPUT.PUT_LINE('ORDERS 테이블 생성 완료');
    ELSE
        DBMS_OUTPUT.PUT_LINE('ORDERS 테이블 이미 존재 - 유지');
    END IF;

    -- ORDER_DETAIL
    SELECT COUNT(*) INTO v_count
      FROM USER_TABLES
     WHERE TABLE_NAME = 'ORDER_DETAIL';

    IF v_count = 0 THEN
        EXECUTE IMMEDIATE '
            CREATE TABLE ORDER_DETAIL (
                DETAIL_ID  NUMBER PRIMARY KEY,
                ORDER_ID   NUMBER,
                MENU_ID    VARCHAR2(10),
                MENU_NAME  VARCHAR2(50),
                QTY        NUMBER,
                UNIT_PRICE NUMBER,
                AMOUNT     NUMBER,
                CONSTRAINT FK_OD_ORDER FOREIGN KEY (ORDER_ID)
                    REFERENCES ORDERS(ORDER_ID),
                CONSTRAINT FK_OD_MENU FOREIGN KEY (MENU_ID)
                    REFERENCES MENU(MENU_ID)
            )';
        DBMS_OUTPUT.PUT_LINE('ORDER_DETAIL 테이블 생성 완료');
    ELSE
        DBMS_OUTPUT.PUT_LINE('ORDER_DETAIL 테이블 이미 존재 - 유지');
    END IF;
END;
/

PROMPT ==========================================
PROMPT 기본 식자재 데이터 추가
PROMPT ==========================================

MERGE INTO INGREDIENT T
USING (
    SELECT 'I001' ING_ID, '돼지고기' ING_NAME, 800 CURRENT_QTY, 1000 MIN_QTY, 'kg' UNIT FROM DUAL
    UNION ALL
    SELECT 'I002', '김치', 5000, 1000, 'kg' FROM DUAL
    UNION ALL
    SELECT 'I003', '쌀', 20000, 5000, 'kg' FROM DUAL
    UNION ALL
    SELECT 'I004', '야채', 3000, 1000, 'kg' FROM DUAL
) S
ON (T.ING_ID = S.ING_ID)
WHEN NOT MATCHED THEN
    INSERT (ING_ID, ING_NAME, CURRENT_QTY, MIN_QTY, UNIT)
    VALUES (S.ING_ID, S.ING_NAME, S.CURRENT_QTY, S.MIN_QTY, S.UNIT);

PROMPT ==========================================
PROMPT 기본 메뉴 데이터 추가
PROMPT ==========================================

MERGE INTO MENU T
USING (
    SELECT 'M001' MENU_ID, '김치찌개' MENU_NAME, 9000 PRICE, '판매중' STATUS FROM DUAL
    UNION ALL
    SELECT 'M002', '불고기덮밥', 10000, '판매중' FROM DUAL
    UNION ALL
    SELECT 'M003', '비빔밥', 9000, '판매중' FROM DUAL
    UNION ALL
    SELECT 'M004', '냉면', 10000, '판매중' FROM DUAL
) S
ON (T.MENU_ID = S.MENU_ID)
WHEN NOT MATCHED THEN
    INSERT (MENU_ID, MENU_NAME, PRICE, STATUS)
    VALUES (S.MENU_ID, S.MENU_NAME, S.PRICE, S.STATUS);

PROMPT ==========================================
PROMPT 메뉴별 식자재 사용량 추가
PROMPT ==========================================

MERGE INTO MENU_INGREDIENT T
USING (
    SELECT 'M001' MENU_ID, 'I001' ING_ID, 0.15 USE_QTY FROM DUAL
    UNION ALL SELECT 'M001', 'I002', 0.20 FROM DUAL
    UNION ALL SELECT 'M002', 'I001', 0.12 FROM DUAL
    UNION ALL SELECT 'M002', 'I003', 0.15 FROM DUAL
    UNION ALL SELECT 'M003', 'I003', 0.15 FROM DUAL
    UNION ALL SELECT 'M003', 'I004', 0.10 FROM DUAL
    UNION ALL SELECT 'M004', 'I003', 0.10 FROM DUAL
    UNION ALL SELECT 'M004', 'I004', 0.08 FROM DUAL
) S
ON (T.MENU_ID = S.MENU_ID AND T.ING_ID = S.ING_ID)
WHEN NOT MATCHED THEN
    INSERT (MENU_ID, ING_ID, USE_QTY)
    VALUES (S.MENU_ID, S.ING_ID, S.USE_QTY);

COMMIT;

PROMPT ==========================================
PROMPT 최종 테이블 목록
PROMPT ==========================================

SELECT TABLE_NAME
  FROM USER_TABLES
 WHERE TABLE_NAME IN
       ('MENU', 'INGREDIENT', 'MENU_INGREDIENT', 'ORDERS', 'ORDER_DETAIL')
 ORDER BY TABLE_NAME;

PROMPT restaurant.sql 실행이 완료되었습니다.
